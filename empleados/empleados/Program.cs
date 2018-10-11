using System;
using System.Collections.Generic;
using System.Text;

namespace empleados
{
    class Program
    {
        public static string[,] registro;
        public static int total;

        static void Main(string[] args)
        {
            //Console.ResetColor();
            //Console.ForegroundColor = ConsoleColor.Yellow;
            string opcion = "";
            total = 0;
            int tottemp;
            registro = new string[20, 4];
            bool sw;
            float pcttemp=0;
            int sumatemp = 0;

            while (opcion != "12" && opcion!="exit")
            {
                Console.WriteLine("Bienvenidos al sistema de incapacidades");
                Console.WriteLine(" ");
                Console.WriteLine("Seleccione una opcion ... ");
                Console.WriteLine(" 1) Captura de nuevo empleado ");
                Console.WriteLine(" 2) Lista de empleados ");
                Console.WriteLine(" 3) Calcular número de empleados con mas de 20 días de incapacidad");
                Console.WriteLine(" 4) Calcular total de empleados incapacitados por enfermedad");
                Console.WriteLine(" 5) Calcular total de empleados incapacitados por accidente");
                Console.WriteLine(" 6) Calcular total de días de incapacidad");
                Console.WriteLine(" 7) Calcular total de hombres incapacitados por accidente");
                Console.WriteLine(" 8) Calcular porcentaje de mujeres incapacitadas");
                Console.WriteLine(" 9) Calcular total de días de incapacidad por enfermedad en mujeres");
                Console.WriteLine(" 10) Calcular promedio de días de incapacidad por enfermedad");
                Console.WriteLine(" 11) Calcular promedio de días de incapacidad por accidente");
                Console.WriteLine(" 12) Salir");
                Console.WriteLine(" ");
                Console.Write("Opcion : ");

                opcion = Console.ReadLine(); 
                Console.Clear();
                Console.WriteLine(" ");
                switch (opcion.ToLower())
                {
                    case "1": /* Captura de empleados */ 
                        string nombre = "";
                        string opsexo = "";
                        string sexo = "";
                        string optipoinc = "";
                        string tipoinc = "";
                        string diasinc = "";

                        Console.WriteLine("Alta de Empleados ");
                        Console.WriteLine(" ");
                        Console.Write("Tecle Nombre de empleado : ");
                        nombre = Console.ReadLine();
                        while (sexo != "Masculino" && sexo != "Femenino")
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Seleccione sexo de empleado");
                            Console.WriteLine(" M) Masculino ");
                            Console.WriteLine(" F) Femenino ");
                            Console.Write(" Opcion : ");
                            opsexo = Console.ReadLine();
                            switch (opsexo.ToUpper())
                            { 
                                case "M":
                                    sexo = "Masculino";
                                    break;
                                case "F":
                                    sexo = "Femenino";
                                    break;
                                default:
                                    Console.WriteLine(" ");
                                    Console.WriteLine("Opcion incorrecta");
                                    break;
                            }
                        }
                        while (tipoinc != "Enfermedad" && tipoinc != "Accidente" &&
                               tipoinc != "Maternidad")
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Seleccione tipo de incapacidad");
                            Console.WriteLine(" E) Enfermedad ");
                            Console.WriteLine(" A) Accidente ");
                            Console.WriteLine(" M) Maternidad ");
                            Console.Write(" Opcion : ");
                            optipoinc = Console.ReadLine();
                            switch (optipoinc.ToUpper())
                            {
                                case "E":
                                    tipoinc = "Enfermedad";
                                    break;
                                case "A":
                                    tipoinc = "Accidente";
                                    break;
                                case "M":
                                    if (opsexo == "F")
                                    {
                                        tipoinc = "Maternidad";
                                    }
                                    else
                                    {
                                        Console.WriteLine(" ");
                                        Console.WriteLine("El empleado : " + nombre);
                                        Console.WriteLine("Es sexo Masculino, por lo tanto no puede ser incapacitado por maternidad");
                                        Console.WriteLine("Favor de verificar");
                                        tipoinc = "";
                                    }

                                    break;
                                default:
                                    Console.WriteLine(" ");
                                    Console.WriteLine("Opcion incorrecta");
                                    break;
                            }
                        }
                        Console.WriteLine(" ");
                        Console.Write("Tecle total de dias de incapacidad : ");
                        diasinc = Console.ReadLine();
                        registro[total, 0] = nombre;
                        registro[total, 1] = sexo;
                        registro[total, 2] = tipoinc;
                        registro[total, 3] = diasinc;
                        total = total + 1;
                        Console.WriteLine(" ");
                        Console.WriteLine("Empleado : " + nombre + " Capturado con exito");
                        break;

                    case "2": /* Lista de empleados */
                        Console.WriteLine("Lista de empleados ");
                        Console.WriteLine(" ");
                        if (total > 0)
                        {
                            Console.WriteLine("Se tiene un total de : " + total + " empleados registrados en el sistema ");
                            Console.WriteLine(" ");
                            for (int i = 0; i < total; i++)
                            {
                                Console.WriteLine("Empleado : " + (i + 1));
                                Console.WriteLine("Nombre : " + registro[i, 0]);
                                Console.WriteLine("Sexo : " + registro[i, 1]);
                                Console.WriteLine("Tipo de incapacidad : " + registro[i, 2]);
                                Console.WriteLine("Total de dias de incapacidad : " + registro[i, 3]);
                                Console.WriteLine("================================================");
                            }
                        }
                        else
                        { Console.WriteLine("De momento no se tienen empleados capturados en el sistema "); }
                        break;

                    case "3": /*  > 20 dias */ 
                        int mayordias = 0;
                        int totdias = 0;
                        for (int i = 0; i < total; i++)
                        {
                            sw = int.TryParse(registro[i, 3], out mayordias);
                            if (sw)
                            {
                                if (mayordias > 20)
                                { totdias = totdias + 1; }
                            }
                        }
                        Console.WriteLine("Total de empleados con mas de 20 dias de incapacidad : " + totdias);
                        break;

                    case "4":
                        tottemp = 0;
                        for (int i = 0; i < total; i++)
                        {
                            if (registro[i, 2] == "Enfermedad")
                            {
                                Console.WriteLine("Nombre : " + registro[i, 0]);
                                tottemp = tottemp + 1;
                            }
                        }
                        Console.WriteLine(" ");
                        Console.WriteLine("Total de empleados incapacitados por enfermedad : " + tottemp);
                        break;

                    case "5":
                        tottemp = 0;
                        for (int i = 0; i < total; i++)
                        {
                            if (registro[i, 2] == "Accidente")
                            {
                                Console.WriteLine("Nombre : " + registro[i, 0]);
                                tottemp = tottemp + 1;
                            }
                        }
                        Console.WriteLine(" ");
                        Console.WriteLine("Total de empleados incapacitados por accidente : " + tottemp);
                        break;

                    case "6":
                        tottemp = 0;
                        for (int i = 0; i < total; i++)
                        {
                            sw = int.TryParse(registro[i, 3], out mayordias);
                            if (sw)
                            {
                                tottemp = tottemp + mayordias;
                            }
                            Console.WriteLine("Nombre : " + registro[i, 0]);
                            Console.WriteLine("Dias de incapacidad : " + registro[i, 3]);
                        }
                        Console.WriteLine(" ");
                        Console.WriteLine("Total de dias de incapacidad : " + tottemp);
                        break;

                    case "7":
                        tottemp = 0;
                        for (int i = 0; i < total; i++)
                        {
                            if (registro[i, 1] == "Masculino" && registro[i, 2] == "Accidente")
                            {
                                Console.WriteLine("Nombre : " + registro[i, 0]);
                                tottemp = tottemp + 1;
                            }
                        }
                        Console.WriteLine(" ");
                        Console.WriteLine("Total de personal masculino incapacitado por accidente : " + tottemp);
                        break;

                    case "8":
                        tottemp = 0;
                        for (int i = 0; i < total; i++)
                        {
                            if (registro[i, 1] == "Femenino")
                            {
                                Console.WriteLine("Nombre : " + registro[i, 0]);
                                tottemp = tottemp + 1;
                            }
                        }
                        if (total == 0) { total = 1; }
                        pcttemp = (tottemp / total) * 100;
                        Console.WriteLine(" ");
                        Console.WriteLine("Porcentaje de personal femenino incapacitado : " + tottemp + "%");
                        break;

                    case "9":
                        tottemp = 0;
                        for (int i = 0; i < total; i++)
                        {
                            if (registro[i, 1] == "Femenino" && registro[i, 2] == "Enfermedad")
                            {
                                sw = int.TryParse(registro[i, 3], out mayordias);
                                if (sw)
                                {
                                    tottemp = tottemp + mayordias;
                                }
                                Console.WriteLine("Nombre : " + registro[i, 0]);
                                Console.WriteLine("Dias de incapacidad : " + registro[i, 3]);
                            }
                        }
                        Console.WriteLine(" ");
                        Console.WriteLine("Total de horas de incapacidad por enfermedad de personal femenino : " + tottemp);
                        break;

                    case "10":
                        tottemp = 0;
                        sumatemp = 0;
                        for (int i = 0; i < total; i++)
                        {
                            if (registro[i, 2] == "Enfermedad")
                            {
                                tottemp = tottemp + 1;
                                sw = int.TryParse(registro[i, 3], out mayordias);
                                if (sw)
                                {
                                    sumatemp = sumatemp + mayordias;
                                }                                
                            }
                        }
                        if (tottemp == 0) { tottemp = 1; }
                        pcttemp = sumatemp / tottemp;
                        Console.WriteLine(" ");
                        Console.WriteLine("Promedio de días de incapacidad por enfermedad : " + pcttemp);
                        break;

                    case "11":
                        tottemp = 0;
                        sumatemp = 0;
                        for (int i = 0; i < total; i++)
                        {
                            if (registro[i, 2] == "Accidente")
                            {
                                tottemp = tottemp + 1;
                                sw = int.TryParse(registro[i, 3], out mayordias);
                                if (sw)
                                {
                                    sumatemp = sumatemp + mayordias;
                                }
                            }
                        }
                        if (tottemp == 0) { tottemp = 1; }
                        pcttemp = sumatemp / tottemp;
                        Console.WriteLine(" ");
                        Console.WriteLine("Promedio de días de incapacidad por accidente : " + pcttemp);
                        break;

                    case "12":
                        Console.WriteLine("Gracias por usar nuestro sistema ... ");
                        break;

                    case "exit":
                        Console.WriteLine("Gracias por usar nuestro sistema ... ");
                        break;

                    default:
                        Console.WriteLine("Opcion incorrecta");
                        break;

                }
                Console.WriteLine(" ");
                Console.Write("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}

