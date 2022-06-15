using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMaterials : MonoBehaviour
{
    private Renderer NoDamageMaterial;
    private Renderer DamagedMaterial;

    public GameObject NoDamageModel;
    public GameObject DamagedModel;
    // Start is called before the first frame update
    void Start()
    {
        NoDamageMaterial = NoDamageModel.GetComponent<Renderer>();
        DamagedMaterial = DamagedModel.GetComponent<Renderer>();


    }


}
