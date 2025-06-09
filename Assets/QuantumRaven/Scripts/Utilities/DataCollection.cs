
using UnityEngine;
[System.Serializable]
public class ItemDetails
{
    //��Ʒ��id,��ͬ��ĸ��ͷ�Ĵ���ͬ�ķ��ࣻ
    public string itemID;

    //��Ʒ������
    public string itemName;

    //��Ʒ���͡���ö��
    public ItemType itemType;

    //��ƷIcon
    public Sprite itemIcon;

    //��Ʒ�������ͼ�ϵ�Icon
    public Sprite itemOnWorldSprite;

    //��Ʒ����
    public string itemDescription;

    //ÿ��Ԫ��ɵ����������
    public int stackableCont;

    //��Ʒ�����÷�Χ�뾶
    public int itemUseRadius;

    //�Ƿ��ʰȡ
    public bool canPickedup;

    //�Ƿ�����ڵ���
    public bool canDropped;

    //�Ƿ���Ծ���
    public bool canCarried;

    //��Ʒ��ֵ
    public int itemPrice;

    //��Ʒ����ʱ������
    [Range(0, 1)]
    public float sellPercentage;

    //���޻ָ�Ч��
    public bool canRecover;
    public int healthPoint; //����ֵ
    public int hungerPoint; //����ֵ
    public int thirstPoint; //�ڿ�ֵ
    //����ʱ��
    public int FreshTime;

    //����Ч��
    public bool specialPoint;

}