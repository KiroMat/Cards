using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GeneratorCards : MonoBehaviour {

    public GameObject PrefabCards;
    public Sprite Background;
    public Sprite Shield;

    private List<Sprite> listOfSprite;
    private List<string> Syllable;

    int minValue = 1;
    int maxValue = 10;

    void Start()
    {
        InitialTabForName();

        var sprites = Resources.LoadAll<Sprite>("Sprite/Card/CuldceptDS_FireCards");
        listOfSprite = sprites.ToList();

        //GetListOfCards();
    }

    public List<GameObject> GetListOfCards(int number = 5)
    {
        List<GameObject> list = new List<GameObject>();

        for (int i = 0; i < number; i++)
        {
            var obj = Instantiate(PrefabCards);
            Card card = obj.GetComponent<Card>();
            if(card != null)
            {
                card.BackgroundImg = Background;
                card.ShieldImg = Shield;
                if (listOfSprite == null)
                    return null;
                card.AvatarImg = listOfSprite[Random.Range(0, listOfSprite.Count)];

                card.TopNumerValue = Random.Range(minValue, maxValue);
                card.BottNumerValue = Random.Range(minValue, maxValue);
                card.LeftNumerValue = Random.Range(minValue, maxValue);
                card.RightNumerValue = Random.Range(minValue, maxValue);

                card.CardName = GenerateName();

                list.Add(obj);
            }
        }

        return list;
    }

    private void InitialTabForName()
    {
        string syllable = "adan ed ain aelin aglat aglar aina alda alqua amarth amon anka an and andune anga anna annon ar ara arien atar band bar barad beleg bragol brethil brith dae dagor del din dol dor draug du duin dur ear echor edhel eithel el elen er ereg esgal falas faroth faug fea fin formen fuin gaer gaur gil girith glin golodh gond gor groth gul gurth gwaith gwath wath hadhod haudh heru him hini hith hoth hyarmen ia iant iath iaur ilm iluve kal gal kalen galen kam kano karak karan kel keleb kemen khelek khil kir koron ku kuivie kul kuru lad laure lnach lin lith lok lom lome londe los loth luin maeg mai man mel men menel mereth minas mir mith mor moth nan nand nar naug ndil dil ndur nur neldor nen nim orn orod os ost palan pel quen quet ram ran rant ras rauko ril rim ring ris roch rom romen rond ros ruin ruth sarn sereg sil thil sir sul tal dal talath tar tathar taur tel thalion thang thar thaur thin thind thol thon thoron til tin tir tol tum tur uial ur val wen wing yave";
        Syllable = syllable.Split(' ').ToList();
    }

    private string GenerateName()
    {
        StringBuilder name = new StringBuilder("");

        int numberSyllable = Random.Range(1, 3);

        while (numberSyllable >= 0)
        {
            int randomNumber = Random.Range(0, Syllable.Count);
            name.Append(Syllable[randomNumber]);
            numberSyllable--;
        }

        name[0] = name[0].ToString().ToUpper()[0];
        return name.ToString();
    }


}
