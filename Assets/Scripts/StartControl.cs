using UnityEngine;

[RequireComponent(typeof(Collider))]
public class StartControl : MonoBehaviour
{
    private Renderer myRenderer;

    public Material inactiveMaterial;
    public Material gazedAtMaterial;
    public Material transparentMaterial;

    private void Start()
    {
        myRenderer = GetComponent<Renderer>();
        SetGazedAt(false);
    }

    public void SetGazedAt(bool gazedAt)
    {
        if(inactiveMaterial != null && gazedAtMaterial != null)
        {
            myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
            return;
        }
    }

    public void SetInactive()
    {
        myRenderer.material = transparentMaterial;
    }
}
