
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
    private string profileEmail = "test@test.sk";
    private string profileAddress = "Romankova 15";
    private string profileID;
    private string profileName;
    private string profileBalance;

    //Tu sa loadne profile do objektu, ktory nasledne budeme pouzivat ako prihlaseneho uzivatela.
    public bankProfile(OleDbConnection con, string profileName, string profilePassword) {
        string hashPassword = generateHash(profilePassword);
        
            try {
                con.Open();
                string query = "SELECT * FROM Uzivatel WHERE Username = @Username";
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
                                Console.WriteLine(this.profileBalance);

                            }
                            else {
                                Console.WriteLine("Nope");
                            }
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

    private void getData(OleDbCommand con) {
        
    }
    
    // Funkcia, ktora vytvori novu instanciu objektu s informaciami (testing)
    /*public bankProfile(string profileName, string profileId, double profileBalance) {
        this.profileName = profileName;
        this.profileBalance = profileBalance;
        this.profileID = profileId;
    }*/

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

    public string getBalance(){
        updateBalance();
        return this.profileBalance;
    }

    // Funckia pre kontrolu zostatku na ucte -> vrati true ak je na ucte dost financii
    public bool validBalance(double amount) {
        updateBalance();
        if (amount < Convert.ToDouble(this.profileBalance)) {
            return true;
        }
        else {
            return false;
        }
    }
    
    public bool dataDeductBalance(double amount) {
        updateBalance();
        try {
            profileBalance = Convert.ToString(Convert.ToDouble(this.profileBalance) - amount);
            // DATABASE: Odobratie balance v databaze
            return true;
        }
        catch (Exception e) {
            return false;
        }
        
    }
    
    public bool dataAddBalance(string receiverId, double amount) {
        updateBalance();
        try {
            // DATABASE: Pridanie balance v databaze kde sa nachadza receiverId
            return true;
        }
        catch (Exception e) {
            return false;
        }
        
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

    private bool updateBalance() {
        try {
            return true;
            // DATABASE: Aktualizovanie balance z databazy
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return false;
        }
        
    }

}