string LastPatch = "1.1.9";
string WantPatch = "1.10.11";
int CompteurPoint = 0;
char[] T_LastPatch = LastPatch.ToCharArray();
char[] T_WantPatch = WantPatch.ToCharArray();
char[] T_LastPatchTest = LastPatch.ToCharArray();//Créer un tableau
int NbCaractereLastPatch = LastPatch.Length;//Calcule le nombre de caractere de LastPatch
int NbCaractereWantPatch = WantPatch.Length;//Calcule le nombre de caractere de WantPatch

bool TestWhile = false;
int CompteurWhile = NbCaractereWantPatch;
//-----------------------Boucle While pour vérifier si c'est un patch mineur ou non-----------------------

while (TestWhile == false)
{
    CompteurWhile--;
    if ((T_WantPatch[CompteurWhile] != '0') | (T_WantPatch[CompteurWhile] == '.'))//Si le dernier est différent de '0' ou que dernier est égal à '.'
    {
        TestWhile = true;
    }
    else
    {
        TestWhile = false;
    }
}

//-----------------------Code-----------------------
if (T_WantPatch[CompteurWhile] != '.')
{
    TestWhile = true;
    CompteurWhile = 0;
    //On teste si les caractères avant le deuxième point sont identiques sinon on renvoie une erreur
    while (CompteurPoint < 2)
    {
        if (T_WantPatch[CompteurWhile] == T_LastPatch[CompteurWhile])
        {
            if (T_WantPatch[CompteurWhile] == '.')
            {
                CompteurPoint++;
            }
        }
        else
        {
            TestWhile = false;
            break;
        }
        CompteurWhile++;
    }
    if (TestWhile == false)
    {
        Console.WriteLine("Erreur avec '" + WantPatch + "' & '" + LastPatch + "'");
        Console.ReadLine();
    }
    else
    {
        TestWhile = true;
        while (CompteurWhile < NbCaractereWantPatch)
        {
            if (NbCaractereLastPatch == CompteurWhile)
            {
                Console.WriteLine("Trop de caractères attendu");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                if (T_WantPatch[CompteurWhile] == T_LastPatch[CompteurWhile])
                {
                    CompteurWhile++;
                }
                else
                {
                    TestWhile = false;
                    break;
                }
            }

        }
        if (TestWhile == true)
        {
            Console.WriteLine("Patch déjà employé");
            Console.ReadLine();
        }
        else
        {
            int compteurWhileBug = 0;
            compteurWhileBug = CompteurWhile + 1;
            if ((T_WantPatch[CompteurWhile] == '1') && (T_LastPatch[CompteurWhile] == '9') && (T_WantPatch[compteurWhileBug] == '0') && (compteurWhileBug == NbCaractereLastPatch))
            {
                string NewPatch = new string(T_WantPatch);
                Console.WriteLine("Nouveau Patch: " + NewPatch);
                Console.ReadLine();
            }
            else
            {
                //CompteurWhile++;
                if ((T_WantPatch[CompteurWhile] == '0') && (T_LastPatch[CompteurWhile] == '9') && (T_WantPatch[compteurWhileBug] == '0'))
                {
                    string NewPatch = new string(T_WantPatch);
                    Console.WriteLine("Nouveau Patch: " + NewPatch);
                    Console.ReadLine();
                }
                else
                {
                    int NbCaractereLastPatch2 = 0;
                    NbCaractereLastPatch2 = NbCaractereLastPatch - 1;
                    int lastNumberPatch = T_LastPatch[NbCaractereLastPatch2];
                    lastNumberPatch++;
                    T_LastPatch[NbCaractereLastPatch2] = (char)lastNumberPatch;
                    string NewPatch = new string(T_LastPatch);
                    if (NewPatch == WantPatch)
                    {
                        Console.WriteLine("Nouveau Patch: " + NewPatch);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Erreur, nous ne ponvons pas passer de '" + LastPatch + "' a '" + WantPatch + "'");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
else
{
    Console.WriteLine("Impossible de déployer un patch mineur");
    Console.ReadLine();
}