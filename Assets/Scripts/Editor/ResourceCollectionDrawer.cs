using UnityEditor;

using UnityEngine;

[CustomPropertyDrawer(typeof(ResourceCollection))]
public class ResourceCollectionDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), GUIUtility.GetControlID(FocusType.Passive), label);

        SerializedProperty quantitiesProperty = property.FindPropertyRelative(nameof(ResourceCollection.Quantities));

        for (int i = 0; i < ResourceScriptableObject.Instances.Count; i++)
        {
            Rect rectangle = position;
            rectangle.y += i * EditorGUIUtility.singleLineHeight;
            rectangle.width /= 2;

            EditorGUI.LabelField(rectangle, ResourceScriptableObject.Instances[i].Name + ':');

            rectangle.x += rectangle.width;
            int newValue = EditorGUI.IntField(rectangle, quantitiesProperty.GetArrayElementAtIndex(i).intValue);
            quantitiesProperty.GetArrayElementAtIndex(i).intValue = newValue;
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) 
            + (ResourceScriptableObject.Instances.Count - 1) * EditorGUIUtility.singleLineHeight;
    }
}
