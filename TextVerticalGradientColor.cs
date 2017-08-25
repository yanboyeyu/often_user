using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextVerticalGradientColor : BaseMeshEffect
{

    public Color colorTop = Color.white;
    public Color colorBottom = Color.black;

    protected TextVerticalGradientColor()
    {

    }

    private static void setColor(List<UIVertex> verts, int index, Color32 c)
    {
        UIVertex vertex = verts[index];
        vertex.color = c;
        verts[index] = vertex;
    }

    private void ModifyVertices(List<UIVertex> verts)
    {
        for (int i = 0; i < verts.Count; i += 6)
        {
            setColor(verts, i + 0, colorTop);
            setColor(verts, i + 1, colorTop);
            setColor(verts, i + 2, colorBottom);
            setColor(verts, i + 3, colorBottom);

            setColor(verts, i + 4, colorBottom);
            setColor(verts, i + 5, colorTop);
        }
    }

    #region implemented abstract members of BaseMeshEffect

    public override void ModifyMesh(VertexHelper vh)
    {
        if (!this.IsActive())
        {
            return;
        }
        List<UIVertex> verts = new List<UIVertex>(vh.currentVertCount);
        vh.GetUIVertexStream(verts);

        ModifyVertices(verts);

        vh.Clear();
        vh.AddUIVertexTriangleStream(verts);
    }

    #endregion
}
