using System.Dynamic;
using System.Data.OleDb;

class bankOperations {

    public bankOperations() {

    }

    public void getStatus(OleDbConnection con, bankProfile profile) {
        profile.getBalance(con);
    }

    public bool sendPayment(OleDbConnection con, bankProfile profile, double amount) {
        try {
            profile.dataDeductBalance(con, amount);
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return false;
        }

    }

    public bool sendTransaction(OleDbConnection con, bankProfile profile, double amount, string receiverId) {
        string profileId = profile.getID();
        if (profile.validBalance(con, amount)) {
            try {

                if (profile.dataDeductBalance(con, amount)) {
                    if (profile.dataAddBalance(con, receiverId, amount)) {
                    }
                    else {
                        Console.WriteLine("Chyba pri transakcii!");
                        profile.dataAddBalance(con, profileId, amount);
                    }
                }
                
                return true;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }
        }
        else {
            Console.WriteLine("Nedostatok peňauzou!!");
            return false;
        }
    }
}