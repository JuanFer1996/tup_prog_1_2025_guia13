using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repasoParcial.Models
{
    internal class Servicio
    {
        private int[] expedientes;
        private int[] dnis;
        private double[] montos;
        private int contador;

        public Servicio()
        {
            expedientes = new int[100];
            dnis = new int[100];
            montos = new double[100];
            contador = 0;
        }

        public void RegistarExpediente(int expediente, int dni, double monto)
        {
            expedientes[contador] = expediente;
            dnis[contador] = dni;
            montos[contador] = monto;
            contador++;
        }

       public void VerExpedientes(int idx, out int numero,out int dni ,out double monto)

        {
            numero = expedientes[idx];
            dni = dnis[idx];
            monto = montos[idx];
        }
       

        public void OrdenarExpedientes()
        {
            for (int i = 0; i < contador - 1; i++)
            {
                for (int j = i + 1; j < contador; j++)
                {
                    if (montos[i] < montos[j])
                    {
                        double auxM= montos[i];
                        int auxE = expedientes[i];
                        int auxDni= dnis[i];    
                        
                        montos[i] = montos [j];
                        expedientes[i]=expedientes [j];
                        dnis[i]=dnis [j];  
                        
                        montos[j]=auxM;
                        expedientes[j]=auxE;
                        dnis [j]=auxDni;
                    }

                }
            }


        }
        public double CalcularMontoPromedio() {
            double prom=0;
            double acum = 0;
            for (int i = 0; i < contador; i++) {
                acum += montos[i];
            }
            prom=acum/contador;


            return prom;
        }

        public int[] MayoresAlPomedio(out int cantidad)
        {
            cantidad = 0;
            int[] idx = new int[100];
            double aux = CalcularMontoPromedio();
            
            for (int i = 0; i < contador; i++) 
            {
                if (montos[i] > aux) { 
                    idx[cantidad] = i;
                    cantidad++;
                }
                
            }
            
            return idx;
        }
        public int VerContador() { 
            return contador;
        }
        public int[] VerExpedientesPorDni(int dni, out int cantidad) { 
            cantidad=0;
            int[] idx = new int[contador];
            for (int i = 0; i < contador; i++)
            {
                if (dnis[i] == dni)
                {
                    idx[cantidad] = i;
                    cantidad++;
                }

            }

            return idx;
        }
        public int VerExpedientesPorNumero(int numero)
        {
            int rtn = -1;
            for (int i = 0; i < contador; i++)
            {
                if (expedientes[i] == numero)
                {
                    rtn = i;
                    return rtn;
                }
            }
            return rtn;
        }
    }
}
