using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {
    //----const----
    public const float MAX_FUEL = 1000;
    public const float SUB_FUEL = 50f;
    public const float ADD_FUEL = 200f;
    public const float HIT_ENEMY_FUEL = 200f;
    public const float SPEED_PER_SECOND = 340;
    //----fields----
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;
    private float _fuel;
    private bool _dead;
    private float _metor;
    private bool _flashing;
    private MeshRenderer _meshRenderer;
    public Slider _slider;
    public Text _metorText;
    public float Metor { get { return _metor; } }

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
        _fuel = MAX_FUEL;
        _dead = false;
        _metor = 0;
        _flashing = false;
        _meshRenderer = GetComponent<MeshRenderer>();
        _slider.maxValue = MAX_FUEL;
	}
	
	// Update is called once per frame
	void Update () {
        FuelUpdate();
        MetorUpdate();
	}

    void FuelUpdate()
    {
        _fuel -= SUB_FUEL * Time.deltaTime; 

        if(_fuel <= 0)
        {
            Debug.Log("Dead");
            _dead = true;
            ScoreData.Instance.Score = _metor;
            GetComponent<SceneChanger>().ChangeScene("Result");
        }

        

    }

    void MetorUpdate()
    {
        _slider.value = _fuel;
        _metor += SPEED_PER_SECOND * Time.deltaTime;
        _metorText.text = (Mathf.Round(_metor / 100) / 10) + "km";
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy" && _flashing == false)
        {
            _fuel -= HIT_ENEMY_FUEL;
            StartCoroutine(Hit());
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator Hit()
    {
        _flashing = true;
        Coroutine flash = StartCoroutine(Flashing());
        yield return new WaitForSeconds(3f);
        StopCoroutine(flash);
        _meshRenderer.enabled = true;
        _flashing = false;
    }

    private IEnumerator Flashing()
    {
        bool flash = false;
        while (true)
        {
            _meshRenderer.enabled = flash;
            yield return new WaitForSeconds(0.2f);
            flash = !flash;
        }
    }

    public void GetFuel()
    {
        _fuel = Mathf.Min(_fuel + ADD_FUEL, MAX_FUEL);
    }
}
