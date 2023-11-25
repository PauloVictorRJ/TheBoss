using TMPro;
using UnityEngine;

public class Placar : MonoBehaviour
{
    public TMP_Text placarText;
    private int placar = 0;

    void Start()
    {
        AtualizarPlacarUI();
    }

    void AtualizarPlacarUI()
    {
        placarText.text = "Pontos: " + placar;
    }

    public void IncrementarPlacar(int pontos)
    {
        placar += pontos;
        AtualizarPlacarUI();
    }
}
