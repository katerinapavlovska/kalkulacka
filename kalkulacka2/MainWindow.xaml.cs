using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kalkulacka2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            
            vysledek.Text = "0";
        }

        int pocetCisel = 0;
        double cislo1 = 0;
        double cislo2 = 0;
        double memory = 0;
        string operace = "";
        bool prepis = true;

        public void tiskCisel(string cislo) {
            if (vysledek.Text == "0"  || prepis || !kontrola(vysledek.Text.ToString())) { vysledek.Text = cislo;
                if (operace != "+" && operace != "-" && operace != "*" && operace != "/" && operace != "rootY" && operace != "xy" && operace != "pi" && operace != "rand" ) {
                    operace = "";
                } }

            else { vysledek.Text +=  cislo; }
            
          
        }

        public bool kontrolaAutomatickaOperace()
        {
            return pocetCisel == 1 && operace != "";
        }

        public bool kontrola(string cislo)
        {
            try
            {
                String preveden = cislo.ToLower();
                Regex vzor = new Regex(@"-?\d*\,?\d*");
                Match shoda = vzor.Match(cislo);
                return preveden.Length == shoda.Value.Length;
            }
            catch (OverflowException ex)
            {
                vysledek.Text = "Na vstupu je příliš velké číslo.";
                return false;
            }
            catch (Exception ex)
            {
                vysledek.Text = ex.Message;
                return false;
            }
        }

        public void pocitat() {
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo2 = prevodCisla(vysledek.Text.ToString());
            }
            else { vysledek.Text = "Nejedná se o číslo v desítkové soustavě."; };
            switch (operace)
            {
                case "+":

                    cislo1 = cislo1 + cislo2;
                    poOperaci("");
                    break;
                case "-":

                    cislo1 = cislo1 - cislo2;
                    poOperaci("");
                    break;
                case "*":

                    cislo1 = cislo1 * cislo2;
                    poOperaci("");
                    break;
                case "/":

                    if (cislo2 == 0) { vysledek.Text = "Nelze dělit 0"; break; }
                    else
                    {
                        cislo1 = cislo1 / cislo2;
                        poOperaci("");
                        break;
                    }
                case "":
                    vysledek.Text = "Nebyla vybrána žádná operace";
                    break;
                case "xy":


                    cislo1 = Operace.mocnina(cislo1, cislo2);
                    poOperaci("");


                    break;
                case "rootY":

                    cislo1 = Operace.mocnina(cislo1, (1.0 / cislo2));
                    poOperaci("");

                    break;
            }
            operace = "=";
            cislo1 = 0;
            cislo2 = 0;
            pocetCisel = 0;
        }

        public void dopocitat()
        {
            if (operace != "") { pocitat(); }
        }
        public void poOperaci (string znakOperace)
        {
            pocetCisel = 1;
            cislo2 = 0;
            vysledek.Text = Convert.ToString(cislo1);
            operace = znakOperace;
            prepis = true;
        }
        public  double prevodCisla(string cislo)
        {
            
            double prevedene = 0;
            if (cislo.Length >= 2 && cislo.StartsWith("0") && !cislo.StartsWith("0,")) { vysledek.Text = "Číslo nesmí začínat 0."; }
            else { prevedene = Convert.ToDouble(cislo); }
                return prevedene;
            
        }

        public void nacteniOperace(string operaceZnak)
        {
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                operace = operaceZnak;
                pocetCisel++;
                prepis = true;
            }
            else { vysledek.Text = "Nejedná se o číslo v desítkové soustavě."; }
        }

        public void nactiDruheCislo ()
        {
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo2 = prevodCisla(vysledek.Text.ToString());
                
            }
            else { vysledek.Text = "Nejedná se o číslo v desítkové soustavě."; }
        }
        private void _0_Click(object sender, RoutedEventArgs e)
        {
            tiskCisel("0");
            prepis = false;
        }

        private void _1_Click(object sender, RoutedEventArgs e)
        {
            tiskCisel("1");
            prepis = false;
        }
        private void _2_Click(object sender, RoutedEventArgs e)
        {
            tiskCisel("2");
            prepis = false;
        }

        private void _3_Click(object sender, RoutedEventArgs e)
        {
            tiskCisel("3");
            prepis = false;
        }
        private void _4_Click(object sender, RoutedEventArgs e)
        {
            tiskCisel("4");
            prepis = false;
        }
        private void _5_Click(object sender, RoutedEventArgs e)
        {
            tiskCisel("5");
            prepis = false;
        }
        private void _6_Click(object sender, RoutedEventArgs e)
        {
            tiskCisel("6");
            prepis = false;
        }

        private void _7_Click(object sender, RoutedEventArgs e)
        {
            tiskCisel("7");
            prepis = false;
        }
        private void _8_Click(object sender, RoutedEventArgs e)
        {
            tiskCisel("8");
            prepis = false;

        }
        private void _9_Click(object sender, RoutedEventArgs e)
        {
            tiskCisel("9");
            prepis = false;
        }

        private void desetina_Click(object sender, RoutedEventArgs e)
        {
            vysledek.Text += ",";
            prepis = false;
        }

        private void Procento_Click(object sender, RoutedEventArgs e)
        {
                dopocitat();
                if (kontrola(vysledek.Text.ToString()))
                {
                    cislo1 = prevodCisla(vysledek.Text.ToString());
                    cislo1 = cislo1 / 100;
                    vysledek.Text = Convert.ToString(cislo1);
                    pocetCisel = 1;
                    prepis = true;

                }
                else { vysledek.Text = "Nejedná se o číslo v desítkové soustavě."; }
            
        }

        private void AC_Click(object sender, RoutedEventArgs e)
        {
            cislo1 = 0;
            cislo2 = 0;
            operace = "";
            pocetCisel = 0;
            memory = 0;
            vysledek.Text = "0";
        }

        private void Csmazat_Click(object sender, RoutedEventArgs e)
        {
            vysledek.Text = "0";
          
          
        }

        private void Plus_minus_Click(object sender, RoutedEventArgs e)
        {
           double cislo = prevodCisla(vysledek.Text.ToString());
           cislo = cislo * (-1);
           if (kontrola(cislo.ToString()))
                { 
                    vysledek.Text = Convert.ToString(cislo);
                    prepis = true;
                }
                else { vysledek.Text = "Nejedná se o číslo v desítkové soustavě."; }
            
        }

        private void Deleni_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
                if (pocetCisel == 1)
                {
                    nactiDruheCislo();
                    if (cislo2 == 0) { vysledek.Text = "Nelze dělit nulou."; }
                    else
                    {
                        cislo1 = cislo1 / cislo2;
                        poOperaci("/");
                    }


                }
                else { nacteniOperace("/"); }
            
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {

            dopocitat();
            if (pocetCisel == 1)
                {
                    nactiDruheCislo();
                    cislo1 = cislo1 - cislo2;
                    poOperaci("-");
                }
            else { nacteniOperace("-"); }
            
        }

        private void Nasobeni_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (pocetCisel == 1)
            {
                nactiDruheCislo();
                cislo1 = cislo1 * cislo2;
                poOperaci("*");
            }
            else { nacteniOperace("*"); }
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (pocetCisel == 1)
            {
                nactiDruheCislo();
                cislo1 = cislo1 + cislo2;
                poOperaci("+");
            }
            else { nacteniOperace("+"); }
        }
        
        private void Rovna_Click(object sender, RoutedEventArgs e)
        {
            pocitat();
        }

        private void rand_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            Random nahodne = new Random();
            double vybrane = nahodne.NextDouble();
            cislo1 = (double)vybrane;
            poOperaci("rand");


        }

        private void pi_Click(object sender, RoutedEventArgs e)
        {

            cislo1 = Math.PI;
            poOperaci("pi");
        }

        private void tanh_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                cislo1 = Math.Tanh(cislo1);
                poOperaci("tanh");
            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void Cosh_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                cislo1 = Math.Cosh(cislo1);
                poOperaci("cosh");
            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void sinh_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                cislo1 = Math.Sinh(cislo1);
                poOperaci("sinh");
            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void tan_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                if (cislo1 % 90 == 0) { vysledek.Text = "Nepřípustná hodnota pro tangens."; }
                else { 
                    double radian;
                      radian  = cislo1 * (Math.PI / 180);
                    cislo1 = Math.Tan(radian);
                    poOperaci("tan");
                }
            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void Cos_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                double radian;
                radian = (cislo1 * Math.PI)/ 180;
                cislo1 = Math.Cos(radian);
                poOperaci("cos");
            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void sin_Click(object sender, RoutedEventArgs e) 
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                
                double radian;
                radian = (cislo1 * Math.PI)/ 180;
                cislo1 = Math.Sin(radian);
                poOperaci("sin");
                    
                
            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void faktorial_Click(object sender, RoutedEventArgs e) 
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());

                cislo1 = Operace.faktorial((int)cislo1);
                if (cislo1 == -1) { vysledek.Text = "Zadaná hodnota je menší než 0."; }
                else { poOperaci("faktorial"); }
                operace = "faktorial";
                
            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void e_Click(object sender, RoutedEventArgs e)
        {
            
            cislo1 = Math.E;
            poOperaci("e");

        }

        private void ln_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());

                
                if (cislo1 <= 0) { vysledek.Text = "Zadaná hodnota je menší nebo rovna 0."; }
                else {cislo1 = Math.Log(cislo1);
                    poOperaci("ln");
                }
                

            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void log10_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                if (cislo1 <=0) { vysledek.Text = "Zadaná hodnota je menší nebo rovna 0.";}
                else
                {
                    cislo1 = Math.Log10(cislo1);
                    poOperaci("log10");
                }


            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void _1_x_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                if (cislo1 == 0) { vysledek.Text = "Nelze dělit 0."; }
                else
                {
                    cislo1 = 1 / cislo1;
                    poOperaci("1/x");
                }


            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void sqrt_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                if (cislo1 < 0) { vysledek.Text = "Zadaná hodnota je menší než 0."; }
                else
                {
                    cislo1 = Math.Sqrt(cislo1);
                    poOperaci("sqrt");
                }


            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void ex_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                cislo1 = Math.Exp(cislo1);
                poOperaci("ex");


            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void _10x_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                cislo1 = Operace.mocnina(10, cislo1);
                poOperaci("10x");


            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void xy_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                operace = "xy";


            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void x3_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                cislo1 = Operace.mocnina(cislo1, 3);
                poOperaci("x3");


            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void x2_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                cislo1 = Operace.mocnina(cislo1, 2);
                poOperaci("x2");


            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void root3_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {   
                cislo1 = prevodCisla(vysledek.Text.ToString());
                if (cislo1 < 0) { vysledek.Text = "Hondota je menší než 0."; }
                else {
                    cislo1 = Operace.mocnina(cislo1, (1.0 / 3.0));
                    poOperaci("root3");
                }

            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void rootY_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                if (cislo1 < 0) { vysledek.Text = "Hodnota je menší než 0."; }
                else {
                    operace = "rootY";
                }
            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void mr_Click(object sender, RoutedEventArgs e)
        {
            vysledek.Text = memory.ToString();
            operace = "mr";
        }
        private void mminus_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                memory -= cislo1;
                operace = "mminus";
            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

        private void mplus_Click(object sender, RoutedEventArgs e)
        {
            dopocitat();
            if (kontrola(vysledek.Text.ToString()))
            {
                cislo1 = prevodCisla(vysledek.Text.ToString());
                memory += cislo1;
                operace = "mplus";
            }
            else { vysledek.Text = "Nejedená se o číslo desítkové soustavy."; }
        }

    }
}
