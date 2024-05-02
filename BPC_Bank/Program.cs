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
    
    bankProfile pro1 = new bankProfile(con, "roman", "test");
    
    /*if (ops.sendTransaction(pro1, 100, "roman")) {
        Console.WriteLine("True");
    }
    else {
        Console.WriteLine("False");
    }*/
}

Main();

