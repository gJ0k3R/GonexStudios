using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintText : MonoBehaviour {

    public GameObject texto;

    string cadena = "";
    long primerOperando = 0, segundoOperando = 0;

    enum Modo { Nada, Suma, Resta, Multipl, Division};
    Modo m = Modo.Nada;

    bool comenzar = true;

	   
	public void Limpiar()
    {
        primerOperando = 0; segundoOperando = 0;
        cadena = "";
        texto.GetComponent<TextMesh>().text = cadena;
    }

    public void NuevoCaracter(string c)
    {
        if (comenzar)
        {
            if(c!= "+" && c != "-" &&c != "/"&& c != "x" )Limpiar();
            comenzar = false;
        }
        cadena += c;
        texto.GetComponent<TextMesh>().text = cadena;
    }

    public void Operando(int n)
    {        
        segundoOperando *= 10;
        segundoOperando += n;
    }




    public void Sumar()
    {
        CambiarModo(Modo.Suma);
    }
    public void Restar()
    {
        CambiarModo(Modo.Resta);
    }
    public void Multiplicar()
    {
        CambiarModo(Modo.Multipl);
    }
    public void Dividir()
    {
        CambiarModo(Modo.Division);
    }

    public void Resultado()
    {
        comenzar = true;
        CambiarModo(Modo.Nada);
        cadena = "" + primerOperando;
        texto.GetComponent<TextMesh>().text = cadena;
    }

    void CambiarModo(Modo mod)
    {
        switch (m)
        {
            case Modo.Suma:
                primerOperando += segundoOperando;
                break;
            case Modo.Resta:
                primerOperando -= segundoOperando;
                break;
            case Modo.Multipl:
                primerOperando *= segundoOperando;
                break;
            case Modo.Division:
                primerOperando /= segundoOperando;
                break;
            default:
                if(segundoOperando != 0) primerOperando = segundoOperando;
                break;
        }
        segundoOperando = 0;
        m = mod;
    }
}
