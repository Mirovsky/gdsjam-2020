using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private FadeInOutManager _fadeInOutManager = default;
    
    public event Action levelLoadedEvent;
    public event Action levelStartEvent;
    public event Action levelFinishedEvent;
    
    private List<TruthAgent> _truthAgents;

    public IReadOnlyList<TruthAgent> truthAgents => _truthAgents;
    
    protected void Awake()
    {
        _truthAgents = new List<TruthAgent>();
    }
    
    protected void Start()
    {
        levelLoadedEvent?.Invoke();
        
        _fadeInOutManager.FadeIn(() =>
        {
            levelStartEvent?.Invoke();
        });
    }

    public void RegisterTruthAgent(TruthAgent truthAgent)
    {
        _truthAgents.Add(truthAgent);
    }

    public float CalculateFinishScore()
    {
        return _truthAgents.Sum(agent => agent.truthAmount);
    }
    
    public void FinishGame()
    {
        // TODO: Not Implemented!
        throw new NotImplementedException();
        
        /* _fadeInOutManager.FadeOut(() =>
        {
            levelFinishedEvent?.Invoke();
        }); */
    }
}
