using Naninovel;
using Naninovel.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{
    public void Click()
    {
		try
		{
            var go = new Goto { Path = new NamedString("Map", "") };
            go.ExecuteAsync().Forget();
        }
		catch (System.Exception)
		{
		}
    }
}
