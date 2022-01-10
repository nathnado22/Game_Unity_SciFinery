using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PeriodicTableGridItem : MonoBehaviour
{
    Text numberText, shortNameText, nameText, weightText;
    Button button;

    public Atom atom;

    public void Start()
    {
        numberText = transform.Find("Number").GetComponent<Text>();
        shortNameText = transform.Find("ShortName").GetComponent<Text>();
        nameText = transform.Find("Name").GetComponent<Text>();
        weightText = transform.Find("Weight").GetComponent<Text>();

        button = GetComponent<Button>();

        SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //var protons = World.Particles.Where(p => p.charge == Particle.Charge.Positive);
        //var neutrons = World.Particles.Where(p => p.charge == Particle.Charge.None);

        // .. TODO: Get atomic number
        //numberText.text = protons.Count().ToString();

        // .. TODO: Get atomic weight
        //weightText.text = (protons.Count()+neutrons.Count()).ToString()+".00";

        var nameWithoutVowels = new string(nameText.text.Where(c => !("aeiou").Contains(c)).ToArray());
        var newShortName = (nameWithoutVowels[0].ToString() + nameWithoutVowels[1].ToString()).ToUpper();
        shortNameText.text = newShortName;
    }

    public void SetActive(bool active)
    {
        numberText.gameObject.SetActive(active);
        shortNameText.gameObject.SetActive(active);
        nameText.gameObject.SetActive(active);
        weightText.gameObject.SetActive(active);
        button.interactable = active;
    }

    // TODO: TEMPORARY number setter for visualisation purposes. TO BE REMOVED
    public void SetNumber(int number) => numberText.text = number.ToString();

    public void SetAtomData(Atom atomData)
    {
        numberText.text = atomData.Number.ToString();
        shortNameText.text = atomData.ShortName;
        nameText.text = atomData.Name;
        weightText.text = atomData.Weight.ToString()+".00";

        atom = atomData;
        SetActive(true);
    }
}