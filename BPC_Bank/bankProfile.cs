
using System.Text;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

class bankProfile{

// Osobne info
    private string profileEmail;
    private string profileAddress;
    private int profileID;
    private string profileName;


    public bankProfile(){
        
    }
    //Tu sa loadne profile do objektu, ktory nasledne budeme pouzivat ako prihlaseneho uzivatela.
    public int loadProfile(string profileName, string profilePassword){
        string databaseName; //sem pride pripojenie do databazy
        return 1;
    }

    public int unloadProfile(){
        this.profileEmail = null;
        this.profileName = null;
        this.profileAddress = null;
        this.profileID = 0;
        return 1;
    }

// Funkcia, ktora vezme udaje uzivatela a vytvori mu ucet.
    public int createProfile(string profileEmail, string profileAddress){ // Vytvorenie profilu s menom a ID (napr obciansky, ...)
        
        return 1;
    }

//Funkcia, ktora na zaklade ID profilu a hesla vymaze ucet.
    public int deleteProfile(){
        // Vymazanie uctu na zaklade ID profilu z databaze.
        return 1;
    }

    public int changeProfileInfo(string profileEmail, string profileAddress){

        return 1;
    }

    public int changeProfileName(string profileName){
        // Zmena mena na zaklade ID v databaze
        return 1;
    }

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

}