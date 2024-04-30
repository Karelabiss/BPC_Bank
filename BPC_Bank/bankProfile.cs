
using System.Text;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

class bankProfile{

                    // Osobne info
    private string profileEmail;
    private string profileAddress;
    private string profileID;
    private string profileName;
    private float profileBalance;


    public bankProfile(){
        
    }
                     //Tu sa loadne profile do objektu, ktory nasledne budeme pouzivat ako prihlaseneho uzivatela.
    public int profileLogin(string profileName, string profilePassword){
                    //Časť ktorá premení heslo na hash, ktorý bude porovnateľný v databáze. (V databáze budú SHA1 hashnuté heslá)
        string hashPassword = generateHash(profilePassword);
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
        
        string profileID = generateHash(hashedPassword+profileName);
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
        string hashedPassword = generateHash(profileNewPassword);
        // Prepisanie noveho hesla do databaze
        return 1;
    }

    public string getID(){
            // ID z profilu
        return this.profileID;
    }

    public float getAccountBalance(){
        //Aktualizacia zostatku
        return this.profileBalance;
    }

    public bool validBalance(float amount) {
        
        /*
        float profileBalance = **databazovy vystup pre balance**;
         
        if (amount < profileBalance) {
            return true;
        }
        else {
            return false;
        }*/
        return true;
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