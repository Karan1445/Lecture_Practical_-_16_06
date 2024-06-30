using Practical3_prog3;

Hdfc hdfc = new Hdfc();
Sbi sbi = new Sbi();
Icici icici = new Icici();  

RBI rbi = new RBI();

rbi.calculateInterest(5000,589,20);

hdfc.calculateInterest(1200, 12, 2);

sbi.calculateInterest(8000, 10, 4.55);

icici.calculateInterest(900, 8, 5.45);