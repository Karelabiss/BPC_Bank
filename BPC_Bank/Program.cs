using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

void Main() {
    bankOperations ops = new bankOperations();
    
    string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Karel\\Documents\\dev\\OOP\\BPC_Bank\\BPC_BANK_Database.accdb";

    OleDbConnection con = new OleDbConnection(connString);
    
    Console.WriteLine("------------ Prihlasenie -----------");
    Console.Write("Zadajte meno: ");
    string name = Console.ReadLine();
    
    Console.Write("Zadajte heslo: ");
    string password = Console.ReadLine();
    
    bankProfile pro1 = new bankProfile(con, name, password);
    
    Console.WriteLine("------------ Vyberte Moznost -----------");
    Console.WriteLine("1 - Zaplatitit transakciu");
    Console.WriteLine("2 - Poslat penize na ucet");
    string f = Console.ReadLine();
    if (f == "2") {
        Console.WriteLine("Zadajte ID prijimatela: ");
        string ID = Console.ReadLine();               
        Console.WriteLine("Zadajte sumu: ");          
        string amount = Console.ReadLine(); 
        ops.sendTransaction(con, pro1, Convert.ToDouble(amount), ID);                         
    }
    else {
        Console.WriteLine("Zadajte sumu: ");   
        string amount = Console.ReadLine();
        ops.sendPayment(con, pro1, Convert.ToDouble(amount));
    }
                                                                                                                                                                                                                                                                                                                                                       

    
    
    
    
    
    
    
    
    


}

Main();

