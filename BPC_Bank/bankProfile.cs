
using System.Text;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

class bankProfile{

                    // Osobne info
    private string profileEmail;
    private string profileAddress;
    private string profileID;
    private string profileName;
    private string profileBalance;

    //Tu sa loadne profile do objektu, ktory nasledne budeme pouzivat ako prihlaseneho uzivatela.
    public bankProfile(OleDbConnection con, string profileName, string profilePassword) {
        string hashPassword = generateHash(profilePassword);
        
            try {
                con.Open();
                string query = "SELECT * FROM Uzivatel WHERE profileName = @Username";
                using (OleDbCommand command = new OleDbCommand(query, con)) {
                    command.Parameters.AddWithValue("@Username", profileName);
                
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve the stored password from the database
                            string storedPassword = reader.GetString(2);
                            if (storedPassword == hashPassword) {
                                Console.WriteLine("Uspech");
                                this.profileID = reader.GetString(1);
                                this.profileName = reader.GetString(3);
                                this.profileEmail = reader.GetString(4);
                                this.profileAddress = reader.GetString(5);
                                this.profileBalance = reader.GetString(6);
                                Console.WriteLine("ProfileNameLogged: " + this.profileName);

                            }
                            else {
                                Console.WriteLine("Nespravne meno alebo heslo!");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nespravne meno alebo heslo!"); 
                            return;
                        }
                    }
                    con.Close();
                }
            
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
    }

    // Funkcia, ktora vynulluje profil
    public bool profileLogout(){
        try {
            this.profileName = null;
            this.profileID = null;
            this.profileBalance = null;
            return true;
            // Funkcia vrati true ak vsetko pojde hladko
        }
        catch (Exception e) {
            return false;
        }
    }

    // Funkcia, ktora vezme udaje uzivatela a vytvori mu ucet.
    public int createProfile(string profileName, string profilePassword, string profileEmail, string profileAddress){ // Vytvorenie profilu s menom a ID (napr obciansky, ...)
        string hashedPassword = generateHash(profilePassword);
        profilePassword = null;
        // Pridat funkciu pre kontrolu ci sa nachadzaju dane hodnoty v databaze
        string profileID = generateHash(hashedPassword+profileName);
        
        //DATABASE: Pridať nový profil
        return 1;
    }
    // Funkcia, ktora vezme ID z profilu a vratiho ho
    public string getID(){
        
        return this.profileID;
    }

    public string getBalance(OleDbConnection con){
        updateBalance(con);
        return this.profileBalance;
    }

    // Funckia pre kontrolu zostatku na ucte -> vrati true ak je na ucte dost financii
    public bool validBalance(OleDbConnection con, double amount) {
        updateBalance(con);
        if (amount < Convert.ToDouble(this.profileBalance)) {
            return true;
        }
        else {
            return false;
        }
    }
    
    public bool dataDeductBalance(OleDbConnection con, double amount) {
        updateBalance(con);
        Console.WriteLine("Balance Pred (-):" + profileBalance);
        try {
            if (amount <= Convert.ToDouble(this.profileBalance)) {
                profileBalance = Convert.ToString(Convert.ToDouble(this.profileBalance) - amount);
                Console.WriteLine("Balance po (-): " + profileBalance);
                try {
                    con.Open();
                    string query = "UPDATE Uzivatel SET balance = ? WHERE profileName = @Username";
                    using (OleDbCommand command = new OleDbCommand(query, con)) {
                        command.Parameters.AddWithValue("@Value1", profileBalance);
                        command.Parameters.AddWithValue("@Username", profileName);

                        int rowsAffected = command.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                    throw;
                }
                return true;
            }
            else {
                Console.WriteLine("Nedostatok Penauzov!");
                return false;
            }
            
        }
        catch (Exception e) {
            return false;
        }
        
    }
    
    public bool dataAddBalance(OleDbConnection con, string receiverId, double amount) {
        updateBalance(con);
        string anotherBalance = "";
        
        try {
            con.Open();
            string query = "SELECT balance FROM Uzivatel WHERE PID = @Username";
            OleDbCommand command = new OleDbCommand(query, con);
            command.Parameters.AddWithValue("@Username", receiverId);

            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read()) {
                anotherBalance = reader.GetString(0);
                Console.WriteLine("AnotherBalance: " + anotherBalance);
            }
            else {
                Console.WriteLine("Neco spatne");
            }
            con.Close();
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
        
        string profileBalanceUser = Convert.ToString(Convert.ToDouble(anotherBalance) + amount);
        try {
            con.Open();
            string query = "UPDATE Uzivatel SET balance = ? WHERE PID = @Username";
            using (OleDbCommand command = new OleDbCommand(query, con)) {
                command.Parameters.AddWithValue("@Value1", profileBalanceUser);
                command.Parameters.AddWithValue("@Username", receiverId);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("This profile: " + this.profileBalance);
                con.Close();
            }
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }

        return true;
    }

    // Funcia pre generovanie hashov pre heslo
    private string generateHash(string Data){
        SHA256 hash256 = SHA256.Create();
        var sBuilder = new StringBuilder();

        byte[] hash = hash256.ComputeHash(Encoding.ASCII.GetBytes(Data));
        
        for (int i = 0; i < hash.Length; i++)
        {
            sBuilder.Append(hash[i].ToString("x2"));
        }

        return sBuilder.ToString();
    }

    private void updateBalance(OleDbConnection con) {
        try {
            con.Open();
            string query = "SELECT * FROM Uzivatel WHERE profileName = @Username";
            using (OleDbCommand command = new OleDbCommand(query, con)) {
                command.Parameters.AddWithValue("@Username", this.profileName);
                
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.profileBalance = reader.GetString(6);
                    }
                    else
                    {
                        Console.WriteLine("Neco spatne"); 
                    }
                }
                con.Close();
            }
            
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
        
    }

}