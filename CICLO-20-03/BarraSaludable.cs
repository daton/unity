using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraSaludable : MonoBehaviour
{
    //Agregamos dos atributos publicos, quiere decir que los vamos a linkear en unity a objetos existentes
    public Slider slider;
    // Vamos a generar un nuevo objeto de tipo Gradient, este es el que vamos cambiar de color
    //dependiendo de qué tanto tengamos de vida en el health.
    public Gradient gradiente;
    //Finalmente agregamos nuestra imagen de relleno, que previamente ya tenemos en nuestro Canvas
    public Image relleno;

    //Este metodo que vamos a poner aqui lo vamos a invocar DESDE EL CODIGO DEL AnimacionesZombi
    public void setMaximoVidas(int vidas)
    {
        //En el slider vamos a invcar su atributo maxValue y le vamos a ajustar el numero de vidas
        slider.maxValue = vidas;
        //Deespues invocamos su atributo que se llama value para asigna el valor actual del slider
        slider.value = vidas;
        //El siguiente renglon va a ir ajustando el gradiente dependiendo de los colores que pusiste
        relleno.color = gradiente.Evaluate(slider.normalizedValue);
    }

    //Este metodo  LOS VAMOS A INVOCAR CADA QUE NOS ALCANCCE UN ZOMBI DE TAL MANERA QUE DISMINUYA EL 
    //RELLENO DEL SLIDER.
    public void setVidas(int salud)
    {
        slider.value = salud;
        relleno.color = gradiente.Evaluate(slider.normalizedValue);
    }

}
