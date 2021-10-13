
using EFConsole.Data;
using EFConsole.Model;
using System;
using System.Linq;

namespace EFConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int value, ID;
                Console.WriteLine("Yapmak istediğiniz işlemi seçin:");
                Console.WriteLine("1.SELECT ALL");
                Console.WriteLine("2.SELECT WITH ID");
                Console.WriteLine("3.INSERT");
                Console.WriteLine("4.UPDATE");
                Console.WriteLine("5.DELETE");
                Console.WriteLine("6.EXIT");
                Console.WriteLine("");
                value = Convert.ToInt32(Console.ReadLine());

                if (value == 1)
                {
                    Console.WriteLine("");
                    ShowClient();
                    Console.WriteLine("");
                }
                else if (value == 2)
                {
                    Console.WriteLine("");
                    Console.WriteLine("ID'yi girin;");
                    ID = Convert.ToInt32(Console.ReadLine());
                    SelectClient(ID);
                    Console.WriteLine("");
                }
                else if (value==3)
                {
                    Console.WriteLine("");
                    InsertClient();
                    Console.WriteLine("");
                    ShowClient();
                }
                else if (value==4)
                {
                    Console.WriteLine("");
                    Console.WriteLine("ID'yi girin;");
                    ID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    SelectClient(ID);
                    Console.WriteLine();
                    UpdateClient(ID);
                    Console.WriteLine("GÜNCELLEME YAPILDI.");
                    SelectClient(ID);
                    Console.WriteLine();
                }
                else if (value==5)
                {
                    Console.WriteLine("");
                    DeleteClient();
                    Console.WriteLine("VERİLEN İD BAŞRILI BİR ŞEKİLDE SİLİNDİ");
                    ShowClient();
                }
                else if (value == 6)
                {
                    break;
                }
            }
        }

    

    static void ShowClient()
    {
        Console.WriteLine("ID - AD SOYAD - DOĞUM TARİHİ - ŞEHİR - TELEFON NO");
        Console.WriteLine("--------------------------------------------------");
        using (var db = new CRMContext())
        {
            var clients = db.Clients.ToList();
            foreach (var c in clients)
            {
                Console.WriteLine("{0}-{1}-{2}-{3}-{4}", c.Id, c.Namesurname, c.Birthdate, c.City, c.Telno);
            }
                db.SaveChanges();
        }

    }

    static void SelectClient(int ID)
    {
        using (var db = new CRMContext())
        {
            var c = db.Clients.Find(ID);
            if (c != null)
            {
                Console.WriteLine("{0}-{1}-{2}-{3}-{4}", c.Id, c.Namesurname, c.Birthdate, c.City, c.Telno);
            }
                else
                {
                    Console.WriteLine("BU ID NUMARASINDA BİR CLIENT BULUNMAMAKTA.");
                }
                db.SaveChanges();
        }

    }

    static void UpdateClient(int ID)
        {
            int section;
            string StringValue;
            Console.WriteLine("HANGİ PARAMETRE DEĞİŞTİRİLSİN 1-) AD SOYAD - 2-) DOĞUM TARİHİ - 3-) ŞEHİR - 4-) TEL NO");
            section =Convert.ToInt32( Console.ReadLine());

            switch (section)
            {
                case 1:
                    using (var db = new CRMContext())
                    {
                        var c = db.Clients.Find(ID);
                        if (c != null)
                        {
                            Console.WriteLine("AD SOYADI GİRİN.");
                            StringValue = Console.ReadLine();
                            c.Namesurname = StringValue;
                        }
                        db.SaveChanges();
                    }
                    break;

                case 2:
                    using (var db = new CRMContext())
                    {
                        var c = db.Clients.Find(ID);
                        if (c != null)
                        {
                            Console.WriteLine("DOĞUM TARİHİ GİRİN.");
                            StringValue = Console.ReadLine();
                            c.Birthdate = Convert.ToDateTime(StringValue);
                        }
                        db.SaveChanges();
                    }
                    break;
                case 3:
                    using (var db = new CRMContext())
                    {
                        var c = db.Clients.Find(ID);
                        if (c != null)
                        {
                            Console.WriteLine("ŞEHİR GİRİN.");
                            StringValue = Console.ReadLine();
                            c.City = StringValue;
                        }
                        db.SaveChanges();
                    }
                    break;
                case 4:
                    using (var db = new CRMContext())
                    {
                        var c = db.Clients.Find(ID);
                        if (c != null)
                        {
                            Console.WriteLine("TEL NO GİRİN.");
                            StringValue = Console.ReadLine();
                            c.Telno = StringValue;
                        }
                        db.SaveChanges();
                    }
                    break;
            }

        }

    static void InsertClient()
        {
            string NS, C, TN;
            DateTime BDate;

            Console.WriteLine("AD SOYAD GİRİN:");
            NS = Console.ReadLine();

            Console.WriteLine("DOĞUM TARİHİ GİRİN:");
            BDate = Convert.ToDateTime( Console.ReadLine());

            Console.WriteLine("ŞEHİR GİRİN:");
            C = Console.ReadLine();

            Console.WriteLine("TELEFON NO GİRİN:");
            TN = Console.ReadLine();

            using (var db=new CRMContext())
            {
                
                Client NewClient = new Client {

                    
                    Namesurname = NS,
                    Birthdate = BDate,
                    City=C,
                    Telno=TN

                };
                db.Clients.Add(NewClient);
                db.SaveChanges();
            }
        }

        static void DeleteClient() {
            int ID;
            Console.WriteLine("SİLİNMESİNİ İSTEDİĞİNİZ İD NUMARASINI GİRİN.");
            ID = Convert.ToInt32( Console.ReadLine());

            using (var db=new CRMContext())
            {
                
                var clients = db.Clients.ToList();
                foreach (var c in clients)
                {
                    if (c.Id==ID)
                    {
                        db.Clients.Remove(c);
                    }
                }
                db.SaveChanges();
            }
        }

    }

}

