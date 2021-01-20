using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ClassA : MonoBehaviour
{
    public bool waitforcompile = false;
    public bool useClassB = false;
    public bool classBswitched = false;

    void Start()
    {

    }

    public void Starter2()
    {
#if CLASSU1
        Debug.Log("Defined");
        ClassB check = null;

        if (check != null)
        {

        }
#else
		Debug.Log("Undefined");
#endif
    }

    void OnGUI()
    {
        if (IfExists() == false)
        {
            if (useClassB)
            {
                classBswitched = false;
                SwitchUseClassB();
            }
        }
    }

    public void SwitchUseClassB()
    {
        if (useClassB)
        {
            if (!PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone).Contains("CLASSU1"))
            {
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, "CLASSU1");
                PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
                waitforcompile = true;
            }
        }
        else
        {
            if (PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone).Contains("CLASSU1"))
            {
                PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, "");
                PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
                waitforcompile = true;
            }
        }
    }

    public bool IfExists()
    {
        bool existsHere = false;
        System.Type classb = System.Type.GetType("ClassB");

        if (classb != null)
        {
            existsHere = true;
        }

        return existsHere;
    }
}
