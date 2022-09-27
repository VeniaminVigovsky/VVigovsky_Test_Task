using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachine
{
    private Dictionary<IState, List<Transition>> _stateTransitions = new Dictionary<IState, List<Transition>>();

    private List<Transition> _currentTransitions = new List<Transition>();

    private List<Transition> _anyTransitions = new List<Transition>();

    private static List<Transition> EmptyTransitions = new List<Transition>();

    private IState _currentState;

    public void AddTransition(IState from, IState to, Func<bool> condition)
    {
        if (!_stateTransitions.TryGetValue(from, out List<Transition> transitions))
        {
            transitions = new List<Transition>();
            _stateTransitions[from] = transitions;            
        }

        transitions.Add(new Transition(to, condition));
    }

    public void AddAnyTransition(IState to, Func<bool> condition)
    {
        _anyTransitions.Add(new Transition(to, condition));
    }

    public void ChangeState(IState newState)
    {
        if (newState == _currentState) return;
        _currentState?.ExitState();
        _currentState = newState;

        _stateTransitions.TryGetValue(_currentState, out _currentTransitions);
        if (_currentTransitions == null)
        {
            _currentTransitions = EmptyTransitions;
        } 

        _currentState?.EnterState();
    }

    public void Tick()
    {
        var transition = GetTransition();
        if (transition != null)
        {
            ChangeState(transition.To);
        }

        _currentState?.Tick(); 
    }

    private Transition GetTransition()
    {
        foreach (var transition in _anyTransitions)
        {
            if (transition.Condition())
            {
                return transition;
            }
        }

        foreach (var transition in _currentTransitions)
        {
            if (transition.Condition())
            {
                return transition;
            }
        }

        return null;
    }

    private class Transition
    {
        public Transition(IState to, Func<bool> condition)
        {            
            To = to;
            Condition = condition;
        }        
        public IState To { get; private set; }

        public Func<bool> Condition { get; private set; }
    }
    
}


