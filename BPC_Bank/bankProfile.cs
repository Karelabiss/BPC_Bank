
using System.Text;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

class bankProfile{

                    // Osobne info
    private string profileEmail;
    private string profileAddress;
    private string profileID;
    private string profileName;


    public bankProfile(string profileName){
        
        Console.WriteLine("Name: " + this.profileName);
        Console.WriteLine("Address: " + this.profileAddress);
        Console.WriteLine("ID: " + this.profileID);
        Console.WriteLine("Email: " + this.profileEmail);

    }
                     //Tu sa loadne profile do objektu, ktory nasledne budeme pouzivat ako prihlaseneho uzivatela.
    public int profileLogin(string profileName, string profilePassword){
                    //Časť ktorá premení heslo na hash, ktorý bude porovnateľný v databáze. (V databáze budú SHA1 hashnuté heslá)
        string hashPassword = generateHash(profilePassword);
        string databaseName; //sem pride pripojenie do databazy
        return 1;
    }

    public int profileLogout(){
        this.profileEmail = null;
        this.profileName = null;
        this.profileAddress = null;
        this.profileID = null;
        return 1;
    }

                    // Funkcia, ktora vezme udaje uzivatela a vytvori mu ucet.
    public int createProfile(string profileName, string profilePassword, string profileEmail, string profileAddress){ // Vytvorenie profilu s menom a ID (napr obciansky, ...)
        string hashedPassword = generateHash(profilePassword);
        profilePassword = null;
        // Pridat funkciu pre kontrolu ci sa nachadzaju dane hodnoty v databaze 
        
        return 1;
    }

                    //Funkcia, ktora na zaklade ID profilu a hesla vymaze ucet.
    public int deleteProfile(){

                    // Vymazanie uctu na zaklade ID profilu z databaze.
        return 1;
    }

    public int changeProfileInfo(string profileEmail, string profileAddress){
        // Prepisanie informacii v databaze
        return 1;
    }

    public int changeProfilePassword(string profileOldPassword, string profileNewPassword)
    {
        // Kontrola stareho hesla v databaze 
        string hashedPassword = generateHash(profileNewPassword)
        // Prepisanie noveho hesla do databaze
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