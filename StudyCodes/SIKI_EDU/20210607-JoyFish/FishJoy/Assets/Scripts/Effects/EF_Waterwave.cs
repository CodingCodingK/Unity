using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EF_Waterwave : MonoBehaviour
{
    public Texture[] textures;// �����ˮ�Ʋ����б�
    private Material material;// ����
    private int index;

    void Start()
    {
	    material = this.GetComponent<MeshRenderer>().material;
	    InvokeRepeating("TextureSlide", 0, 0.1f);
    }

    private void TextureSlide()
    {
	    material.mainTexture = textures[index];
	    index = (index+1) % textures.Length;
    }
}
