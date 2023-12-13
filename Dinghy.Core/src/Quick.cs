using System.Reflection;
using Arch.Core;
using Dinghy.Core.ImGUI;
using Dinghy.Internal.Sokol;
using Volatile;

namespace Dinghy;

public static class Quick
{
    public static Random Random = new System.Random();
    public static int RandInt() => Random.Next();
    public static float RandFloat() => Random.NextSingle();
    public static double RandDouble() => Random.NextDouble();
    
    public static double Map(double value, double fromSource, double toSource, double fromTarget, double toTarget)
    {
        return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
    }
    
    public static float MapF(float value, float fromSource, float toSource, float fromTarget, float toTarget)
    {
        return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
    }

    public static void MoveToMouse(Entity e)
    {
        e.X = (int)InputSystem.MouseX;
        e.Y = (int)InputSystem.MouseY;
    }

    public static Vector2 RandUnitCircle()
    {
        var radian = RandDouble() * Math.PI * 2;
        return new Vector2(
            (float)Math.Cos(radian),
            (float)Math.Sin(radian));
    }
    public static List<Frame> HorizontalFrameSequence(int startX, int startY, int frameWidth, int frameHeight, int frameCount)
    {
        List<Frame> frames = new List<Frame>();
        for (int i = 0; i < frameCount; i++)
        {
            frames.Add(new Frame(startX + i * frameWidth, startY, frameWidth, frameHeight));
        }

        return frames;
    }

    public static Action Update
    {
        get => Engine.Update;
        set => Engine.Update += value;
    }
    
    public static Action Setup
    {
        get => Engine.Setup;
        set => Engine.Setup += value;
    }
    public static Action<Key,List<Modifiers>> OnKeyDown
    {
        get => InputSystem.Events.Key.Down;
        set => InputSystem.Events.Key.Down += value;
    }
    
    public static Action<Key,List<Modifiers>> OnKeyPressed
    {
        get => InputSystem.Events.Key.Pressed;
        set => InputSystem.Events.Key.Pressed += value;
    }
    
    public static Action<Key,List<Modifiers>> OnKeyUp
    {
        get => InputSystem.Events.Key.Up;
        set => InputSystem.Events.Key.Up += value;
    }

    
    static Func<FieldInfo,bool> DefaultFieldSkipFunction = (field) => true;
    static BindingFlags FieldBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy;

    public static void DrawEditGUIForObject<T>(string name, ref T obj, Func<FieldInfo, bool> validFieldCheck = null)
    {
        ImGUIHelper.Wrappers.SetNextWindowPosition(10, 10, ImGuiCond_.ImGuiCond_Once, 0, 0);
        ImGUIHelper.Wrappers.Begin(name, ImGuiWindowFlags_.ImGuiWindowFlags_None);
        validFieldCheck = validFieldCheck == null ? DefaultFieldSkipFunction : validFieldCheck;
        DrawObjectFields(name,ref obj,validFieldCheck);
        ImGUIHelper.Wrappers.End();
    }

    private static void DrawObjectFields<T>(string objectName, ref T o, Func<FieldInfo, bool> validFieldCheck)
    {
        Type t = o.GetType();
        var sortedFields = new List<(int priority,FieldInfo field)>();
        foreach (var field in t.GetFields(FieldBindingFlags).Where( x => validFieldCheck(x)))
        {
            // var attr = (FieldOrder) Attribute.GetCustomAttribute(field, typeof(FieldOrder));
            // var priority = attr != null ? attr.Priority : 99;
            // sortedFields.Add((priority,field));
            sortedFields.Add((1,field));
        }
        foreach (var sortedField in sortedFields.OrderBy(x => x.priority))
        {
            var fieldInfo = sortedField.field;
            // var attr = (EditableField) System.Attribute.GetCustomAttribute(fieldInfo, typeof (EditableField));
            // if(attr == null)
            // {
                //use a default editor for any un-annotated field types
                if(fieldInfo.FieldType.IsEnum)
                {
                    // prefab = ScenarioEditorManager.Instance.ToggleGroup;
                }
                else if (fieldInfo.FieldType.IsClass || fieldInfo.FieldType.IsGenericType)
                {
                    var cv = fieldInfo.GetValue(o);
                    if (cv != null)
                    {
                        ImGUIHelper.Wrappers.Text(fieldInfo.Name);
                        DrawObjectFields(fieldInfo.Name,ref cv,validFieldCheck);
                    }
                }
                else
                {
                    switch (fieldInfo.FieldType.Name)
                    {
                        case nameof(String):
                            // prefab = ScenarioEditorManager.Instance.TextInput;
                            break;
                        case nameof(Int32):
                            // prefab = ScenarioEditorManager.Instance.IntInput;
                            break;
                        case nameof(Single):
                            float v = (float)fieldInfo.GetValue(o);
                            ImGUIHelper.Wrappers.SliderFloat(objectName + "_" + fieldInfo.Name, ref v, 1f, 1000f, "",
                                ImGuiSliderFlags_.ImGuiSliderFlags_None);
                            fieldInfo.SetValueDirect(__makeref(o), v);
                            // fieldInfo.SetValue(o,v);
                            break;
                        case nameof(Boolean):
                            // prefab = ScenarioEditorManager.Instance.WrappedBool;
                            break;
                        default:
                            Console.WriteLine(fieldInfo.FieldType.Name);
                            break;
                    }

                    // if( prefab == null)
                    // {
                    //     var fieldType = fieldInfo.FieldType;
                    //     if(fieldType.IsGenericType)
                    //     {
                    //         //https://stackoverflow.com/questions/45487884/c-sharp-reflection-check-that-fieldtype-is-some-list
                    //         //https://stackoverflow.com/questions/1043755/c-sharp-generic-list-t-how-to-get-the-type-of-t
                    //         var typeArg = fieldType.GetGenericArguments()[0];
                    //         if(typeArg == typeof(TriggerAction))
                    //         {
                    //             prefab = ScenarioEditorManager.Instance.ScenarioTriggerActionList;
                    //         }
                    //         else if(typeArg == typeof(TriggerCondition))
                    //         {
                    //             prefab = ScenarioEditorManager.Instance.ScenarioTriggerConditionList;
                    //         }
                    //     }
                    // }
                }
            // }
            // else
            // {
            //     if(attr is NonEditable) {continue;}
            //     else
            //     {
            //         var field = Util.InstantiateAtParent(attr.Prefab, Root).GetComponent<EditorField>();
            //         field.Setup(o,fieldInfo,ViewPanel,attr);
            //     }
            // }
        } 
    }
}
