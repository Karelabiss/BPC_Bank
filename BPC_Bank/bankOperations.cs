using System.Dynamic;

class bankOperations {

    public bankOperations() {

    }

    public void getStatus(bankProfile profile) {
        profile.getBalance();
    }

    public bool sendPayment(bankProfile profile, double amount) {
        try {
            profile.dataDeductBalance(amount);
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return false;
        }

    }

    public bool sendTransaction(bankProfile profile, double amount, string receiverId) {
        string profileID = profile.getID();
        if (profile.validBalance(amount)) {
            try {
                profile.dataDeductBalance(amount);
                profile.dataAddBalance(receiverId, amount);
                return true;
                // DATABASE: Pridat amount na druhy ucet
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }
            // Kontrola zostatku na účte + prenesenie financií v databáze do daného uctu 
        }
        else {
            return false;
        }
    }
}