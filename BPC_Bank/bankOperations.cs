using System.Dynamic;

class bankOperations{

    public bankOperations(){
        
    }
    
    public void getStatus(bankProfile profile){
        profile.getAccountBalance();
    }

    public void sendPayment(bankProfile profile, float amount, string receiverId){
        string profileID = profile.getID();
        // Kontrola zostatku na účte + prenesenie financií v databáze do daného 
    }

    public void sendTransaction(bankProfile profile, float amount) {
        
    }
}