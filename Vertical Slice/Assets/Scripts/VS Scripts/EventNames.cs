using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum TimeOfDay {Unchanged, Morning, Day, Night}
public static class EventNames
{
    public static string NewTimeEvent = "NewTimeEvent";
}

[UnitTitle("On NewTimeEvent")]//The Custom Scripting Event node to receive the Event. Add "On" to the node title as an Event naming convention.
[UnitCategory("Events\\MyEvents")]//Set the path to find the node in the fuzzy finder as Events > My Events.
public class NewTimeEvent : EventUnit<TimeOfDay>
{
  [DoNotSerialize]// No need to serialize ports.
  public ValueOutput result { get; private set; }// The Event output data to return when the Event is triggered.
  protected override bool register => true;

  // Add an EventHook with the name of the Event to the list of Visual Scripting Events.
  public override EventHook GetHook(GraphReference reference)
  {
      return new EventHook(EventNames.NewTimeEvent);
  }

  protected override void Definition()
  {
      base.Definition();
      // Setting the value on our port.
      result = ValueOutput<TimeOfDay>(nameof(result));
  }

  // Setting the value on our port.
  protected override void AssignArguments(Flow flow, TimeOfDay data)
  {
      flow.SetValue(result, data);
  }
}