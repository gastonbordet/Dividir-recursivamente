using System;

namespace tareaReloaded
{
    class Program
    {
        static int CalcularCocienteIteracion(int dividendo, int divisor, int resto, int cociente = 1)
        {
            while (dividendo - divisor > 0) 
            {   if (dividendo - divisor > 0)
                    cociente++;
                dividendo -= divisor;
            }

            // ! Si el resto no es 0 necesito restarle un numero para calcular el decimal.
            return resto == 0 ? cociente : cociente - 1;
        }

        static int CalcularCocienteRecursiva(int dividendo, int divisor, int resto, int cociente = 1) 
        {
            if (dividendo - divisor <= 0) 
            {
                // ! Si el resto no es 0 necesito restarle un numero para calcular el decimal.
                return resto == 0 ? cociente : cociente - 1;
            }

            cociente++;
            return CalcularCocienteRecursiva(dividendo - divisor, divisor, resto, cociente);
        }
        
        static float DividirDecimalesRecursivaSinDivision(int dividendo, int divisor, int resto, int cociente = 1, string res = "") 
        {
            // * Si el dividendo es 0 el cociente siempre sera 0.
            if (dividendo == 0)
            {
                return 0;
            }

            // * Si el resto es 0 el cociente sera entero.
            if (resto == 0) 
            {
                res += CalcularCocienteRecursiva(dividendo, divisor, resto, cociente);
                float result = float.Parse(res);
                return result;
            }

            // ! Ejecuto solo la primera vez para conseguir el primer numero del cociente
            if (res == "") 
            {
                res += CalcularCocienteRecursiva(dividendo, divisor, resto, cociente).ToString() + ",";
            }
            else 
            {
                res += CalcularCocienteRecursiva(dividendo, divisor, resto, cociente).ToString();
            }
            
            // * Agrega 0 al resto y vuelve a calcular un nuevo resto.
            dividendo = resto * 10;
            resto = dividendo % divisor;

            return DividirDecimalesRecursivaSinDivision(dividendo, divisor, resto, cociente, res);    
        }

        static float DividirDecimalesRecursivaSinDivision2(int dividendo, int divisor, int resto, int cociente = 1, float res = 0) 
        {
            // * Si el dividendo es 0 el cociente siempre sera 0.
            if (dividendo == 0)
            {
                return 0;
            }

            // * Si el resto es 0 el cociente sera entero.
            if (resto == 0) 
            {
                res += CalcularCocienteRecursiva(dividendo, divisor, resto, cociente);
                if (res < 100) res *= 10; 
                return res * (float) 0.01;
            }

            else 
            {
                res = res * 10 + CalcularCocienteRecursiva(dividendo, divisor, resto, cociente) * 10;
            }
            
            // * Agrega 0 al resto y vuelve a calcular un nuevo resto.
            dividendo = resto * 10;
            resto = dividendo % divisor;

            return DividirDecimalesRecursivaSinDivision2(dividendo, divisor, resto, cociente, res);    
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(DividirDecimalesRecursivaSinDivision(21, 4, 21%4));
            Console.WriteLine(DividirDecimalesRecursivaSinDivision2(21, 4, 21%4));
            //Console.WriteLine(DividirDecimalesRecursivaSinDivision(13, 5, 13%5));
            Console.WriteLine(DividirDecimalesRecursivaSinDivision2(13, 5, 13%5));
            Console.WriteLine(CalcularCocienteRecursiva(8, 4, 8%4));
            Console.WriteLine(CalcularCocienteRecursiva(9, 4, 9%4));
            Console.WriteLine(CalcularCocienteIteracion(12, 4, 12%4));
            Console.WriteLine(CalcularCocienteIteracion(13, 4, 13%4));
        }
    }
}
