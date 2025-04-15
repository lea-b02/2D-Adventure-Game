using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    //pour le demarage de jeux comme un banay
    public void SetMaxHealth(int healt) { 
    slider.maxValue = healt;
    slider.value = healt;

    //gauch0 droit1 cela va de 0 a 1 donc il commence part le 1
    fill.color = gradient.Evaluate(1f);
    }

    // quelle sont les point de vie a affiche (quand le personnage va prendre des dega ou quand on lui donne de la vie)
    public void SetHealth(int healt) {
        slider.value = healt;
        //on va recuperet la couleur qui est a slider.normalizedValue den mon gradient entre 0 et 100 donc 82 devient 0.82
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    
}
