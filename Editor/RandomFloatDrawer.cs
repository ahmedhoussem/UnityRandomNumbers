using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(RandomFloat))]
public class RandomFloatDrawer : PropertyDrawer
{
    const float HEIGHT = 17f;
    const float LABEL_WIDTH = 30f;
    const float TOGGLE_SIZE = 20f;
    const float OS_MODE = 60f;

    private float WidthFieldAndLabel;

    GUIContent PropertyLabelContent;
    GUIStyle OSModeStyle;

    Rect PropertyLabel, TooltipLabel, BoolRect, MaxLabel, MinLabel;
    Rect MinRect, MaxRect;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //Create the dimentions of the rects
        InitRects( position );

        //Update
        property.serializedObject.Update();

        //Save field refrences
        var OneShot = property.FindPropertyRelative("OneShotMode");
        var Min = property.FindPropertyRelative("Min");
        var Max = property.FindPropertyRelative("Max");

        PropertyLabelContent = new GUIContent() { text = "OS Mode", tooltip = "One Shot Mode : is used for constant random value" };
        OSModeStyle = new GUIStyle() { fontStyle = FontStyle.Bold };

        //Build the editor
        EditorGUI.BeginProperty(position, label, property);


        EditorGUI.LabelField(PropertyLabel , label);

        EditorGUI.LabelField(TooltipLabel, PropertyLabelContent , OSModeStyle);
        OneShot.boolValue = EditorGUI.Toggle(BoolRect, property.FindPropertyRelative("OneShotMode").boolValue);

        EditorGUI.LabelField(MaxLabel, "Max");
        Max.floatValue = EditorGUI.FloatField(MaxRect, property.FindPropertyRelative("Max").floatValue);

        EditorGUI.LabelField(MinLabel, "Min");
        Min.floatValue = EditorGUI.FloatField(MinRect, property.FindPropertyRelative("Min").floatValue);

        EditorGUI.EndProperty();


        //Save the changes
        property.serializedObject.ApplyModifiedProperties();

    }
    private void InitRects(Rect position)
    {
        PropertyLabel = new Rect(position.x,
                                position.y,
                                EditorGUIUtility.labelWidth,
                                HEIGHT);

        TooltipLabel = new Rect(position.x + EditorGUIUtility.labelWidth,
                                position.y,
                                OS_MODE,
                                HEIGHT);

        BoolRect = new Rect(position.x + EditorGUIUtility.labelWidth + OS_MODE,
                                position.y,
                                TOGGLE_SIZE,
                                HEIGHT);

        WidthFieldAndLabel = (position.width - (position.x + EditorGUIUtility.labelWidth + OS_MODE + TOGGLE_SIZE)) * 0.5f;

        MinLabel = new Rect(position.x + EditorGUIUtility.labelWidth + OS_MODE + TOGGLE_SIZE,
                               position.y,
                               LABEL_WIDTH,
                               HEIGHT);


        MinRect = new Rect(position.x + EditorGUIUtility.labelWidth + OS_MODE + TOGGLE_SIZE + LABEL_WIDTH,
                               position.y,
                               WidthFieldAndLabel - LABEL_WIDTH,
                               HEIGHT);


        MaxLabel = new Rect(position.x + EditorGUIUtility.labelWidth + TOGGLE_SIZE + OS_MODE + WidthFieldAndLabel,
                               position.y,
                               LABEL_WIDTH,
                               HEIGHT);

        MaxRect = new Rect(position.x + EditorGUIUtility.labelWidth + TOGGLE_SIZE + OS_MODE + WidthFieldAndLabel + LABEL_WIDTH,
                               position.y,
                               WidthFieldAndLabel - LABEL_WIDTH,
                               HEIGHT);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return HEIGHT;
    }
}
