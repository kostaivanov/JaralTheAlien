using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentFunctions : MonoBehaviour
{
    internal static PermanentFunctions instance;
    [SerializeField] private ParticleSystem starsBackground;

    public float simulationSpeedDefault = 1.0F;

    internal int initialMeteoriteSpeed = 14;
    
    internal int laserCount = 0;
    internal int laserCount_Max = 20;
    internal int laserBigBlastCount = 0;
    internal int laserBigBlastCount_Max = 1;
    internal bool canShoot = false;
    internal bool canShootBigBlast = false;
    internal float meteoriteSpeed = 14f;

    internal float meteoriteSpeedIncrease = 3f;
    //internal float starsStartSpeedDefault = 5f;
    //internal float starsInitialSpeed = 5f;

    internal float starsSimulationSpeedDefault = 1f;

    internal delegate void IncrSpeedWithTime();
    internal IncrSpeedWithTime OnIncreaseSpeed;

    internal bool keepWaiting = false;

    internal int score = 0;

    private void Awake()
    {

        //checking if there is isntance of this object, if not, create one
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);

        }
        //if there was already instance of the object, destroy it, to aovid multiple gameobject of this type
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {

        //InvokeRepeating("OnIncreaseSpeed", 60f, 60f);
        meteoriteSpeed = 14f;
    }

    internal void IncreaseSpeedWithTime()
    {
        PermanentFunctions.instance.meteoriteSpeed += meteoriteSpeedIncrease;

        //OnIncreaseSpeed();

        var main = starsBackground.main;
        //var emission = starsBackground.emission;

        //starsSpeed += speedIncrease;
        main.simulationSpeed += 0.4f;

        //emission.rateOverTime = main.simulationSpeed * 50f;
    }

    //internal void SetTodefaultSpeed()
    //{
    //    var main = starsBackground.main;
    //    //var emission = starsBackground.emission;

    //    //starsSpeed += speedIncrease;
    //    main.simulationSpeed = simulationSpeedDefault;
    //    //emission.rateOverTime = 50f;
    //}

    internal IEnumerator IncreaseSpeedObjectAtIntervals(float secondsBetweenSpawns)
    {
        // Repeat until keepSpawning == false or this GameObject is disabled/destroyed.
        while (keepWaiting)
        {
            // Put this coroutine to sleep until the next spawn time.
            yield return new WaitForSecondsRealtime(secondsBetweenSpawns);
            // Now it's time to spawn again.
            OnIncreaseSpeed();
        }
    }
}
