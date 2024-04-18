
using System.Text;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

class bankProfile{

// Security info
    private string profilePrivateSID; // Privatne SecurityID, ktore vygenerujeme na zaklade ID
    private string profilePublicSID; // Public SecurityID, ktore vygenerujeme na zaklade ID

// Osobne info
    private string profileEmail;
    private string profileAddress;
    private int profileID;
    private string profileName;
    private string profilePassword;


    public bankProfile(){
        
    }

// Funkcia, ktora vezme udaje uzivatela a vytvori mu ucet.
    public int createProfile(string profileName, string profilePassword, string profileEmail, string profileAddress){ // Vytvorenie profilu s menom a ID (napr obciansky, ...)
        
        return 1;
    }

//Funkcia, ktora na zaklade ID profilu a hesla vymaze ucet.
    public int deleteProfile(string profileID, string profilePassword){
        // Vymazanie uctu na zaklade ID profilu z databaze.
        return 1;
    }

    public int changeProfileInfo(string profileID, string profilePassword, string profileEmail, string profileAddress){
        if(profileEmail == null){
            profileEmail = profileEmail;
        }
        else if(profileAddress == null){
            profileAddress = profileAddress;
        }

        return 1;
    }

    public int changeProfileName(string profileID, string profilePassword, string profileName){
        // Zmena mena na zaklade ID v databaze
        return 1;
    }

    private int generateProfilePrivateSID(int ID){
        return ID * 35;
    }

    private int generateProfilePublicSID(int ID){
        return ID * 70;
    }

    private string generateHash(string profileName){
        SHA256 hash256 = SHA256.Create();
        byte[] stri = Encoding.ASCII.GetBytes(profileName);
        byte[] hash = hash256.ComputeHash(stri);
        var sBuilder = new StringBuilder();

        for (int i = 0; i < hash.Length; i++)
        {
            sBuilder.Append(hash[i].ToString("x2"));
        }

        return sBuilder.ToString();;
    }

}