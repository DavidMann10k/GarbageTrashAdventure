using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class TruckController : Bolt.EntityEventListener<ITruckState>
{
    static Random rnd = new Random();

    [SerializeField]
    GameObject cam = null;

    [SerializeField]
    GameObject arm = null;

    [SerializeField]
    Transform can_drop_spot = null;

    [SerializeField]
    Renderer truck_renderer = null;

    [SerializeField]
    Text[] texts;

    [SerializeField]
    Transform[] garbage_drop;

    Renderer arm_renderer = null;
    float arm_color_reset = 0.0f;

    GameObject can = null;

    Bolt.PrefabId[] garbage_ids;

    private void Start()
    {
        garbage_ids = new Bolt.PrefabId[3];

        garbage_ids[0] = BoltPrefabs.GarbageLeftovers;
        garbage_ids[1] = BoltPrefabs.GarbagePaper;
        garbage_ids[2] = BoltPrefabs.GarbageTakeout;
    }

    public override void Attached()
    {
        arm_renderer = arm.GetComponent<Renderer>();

        state.SetTransforms(state.TruckTransform, transform);

        if (entity.isOwner)
        {
            cam.SetActive(true);
            state.TruckColor = new Color(Random.value, Random.value, Random.value);
            state.TruckName = getRandomName();

        }
        state.AddCallback("TruckColor", ColorChanged);
        state.AddCallback("TruckName", NameChanged);
    }

    void NameChanged()
    {
        foreach(Text text in texts)
        {
            text.text = state.TruckName;
        }
        Debug.Log("NAME CHANGED");
    }

    void ColorChanged()
    {
        truck_renderer.material.color = state.TruckColor;
    }

    private void Update()
    {
        if(Input.GetAxis("Jump") > 0)
        {
            if (can != null)
            {
                //can.transform.Translate(can_drop_spot.position - can.transform.position);

                var evnt = ArmEvent.Create(this.entity);
                evnt.ColorOn = false;
                evnt.Send();

                can = null;

                for (int i = 0; i < 3; i++)
                {
                    BoltNetwork.Instantiate(garbage_ids[i], garbage_drop[i].position, Quaternion.identity);
                }
            }
        }

        if (Input.GetAxis("Submit") > 0)
        {
            transform.position = StartingSpot.GetRandomStartingSpot().transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (entity.isOwner)
        {
            if (other.CompareTag("Can"))
            {
                can = other.gameObject;
                var evnt = ArmEvent.Create(this.entity);
                evnt.ColorOn = true;
                evnt.Send();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (can == null || other == null)
        {
            return;
        }

        if (entity.isOwner)
        {
            if (other.gameObject.GetInstanceID() == can.GetInstanceID())
            {
                can = null;

                var evnt = ArmEvent.Create(this.entity);
                evnt.ColorOn = false;
                evnt.Send();
            }
        }
    }

    public override void OnEvent(ArmEvent evnt)
    {
        if (evnt.ColorOn)
        {
            arm_renderer.material.color = Color.red;
        } else
        {
            arm_renderer.material.color = Color.white;
        }
    }

    string getRandomName()
    {
        var names = (new[] {
            "The Garbage Inspector",
            "Haulin' Yer Junk",
            "Food Consignment",
            "Sludge Lake Disposal",
            "College Salvage",
            "2nd Life Appliance",
            "Cash 4 Trash",
            "Upcycled Style",
            "Derelicte Fashions",
            "Hogwash Services",
            "Garbage, Your Way",
            "The Street Kleener",
            "Litter Terminator",
            "Sewer Sharks",
            "Pest Control",
            "Back Alley Buddy",
            "Just The Trash, Ma'am",
            "We Love Your Cans",
            "Trashnado",
            "Da Trashman",
            "How's My Driving?",
            "Trash Rustler",
            "Gutter Patrol",
            "Sewer Fresh",
            "Parks and Sanitation",
            "Septic Skeptic",
            "Junk Everest",
            "Waste Not",
            "3rd Life Donations",
            "Gimme! Gimme! Gimme!",
            "Recycle This",
            "Dignitfied Sanitation",
            "Six Wheels and Flies",
            "That's Just Rubbish",
            "Junkaholic",
            "Flotsam",
            "Jetsam",
            "Crud Crew",
            "Wreckage Warrior",
            "Slop Purveyor",
            "Scrap Sisters",
            "Bilge Brothers",
            "Balderdash",
            "Rot Robbers",
            "Can Crusher",
            "Main Drain Clog Removal",
            "Garbage and Telegrams LTD",
            "Haulin' Ass",
            "Sideswipe Inc"});
        return names[Random.Range(0,names.Length)];
    }
}