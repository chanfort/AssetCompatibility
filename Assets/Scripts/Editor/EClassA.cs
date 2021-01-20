using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ClassA))]
public class EClassA : Editor
{
    public ClassA classA;

    public override void OnInspectorGUI()
    {
        classA = (ClassA)target;

        if (classA.waitforcompile)
        {
            if (EditorApplication.isCompiling == false)
            {
                classA.waitforcompile = false;
                classA.Starter2();
            }
        }

        EditorGUILayout.BeginHorizontal();
        GUILayout.Space(20);

        if (classA.IfExists())
        {
            classA.useClassB = GUILayout.Toggle(classA.useClassB, "Use Class B");

            if (classA.useClassB != classA.classBswitched)
            {
                classA.classBswitched = classA.useClassB;
                classA.SwitchUseClassB();
            }
        }
        else
        {
            if (classA.useClassB)
            {
                classA.classBswitched = false;
                classA.SwitchUseClassB();
            }
        }

        EditorGUILayout.EndHorizontal();
    }
}
