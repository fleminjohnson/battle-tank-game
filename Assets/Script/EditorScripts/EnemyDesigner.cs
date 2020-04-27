using UnityEditor;
using UnityEngine;

public class EnemyDesigner : EditorWindow
{
    [MenuItem("Window/EnemyDesigner")]
    static void OpenWindow()
    {
        EnemyDesigner window = (EnemyDesigner)GetWindow(typeof(EnemyDesigner));
        window.minSize = new Vector2(600,300);
    }
}
