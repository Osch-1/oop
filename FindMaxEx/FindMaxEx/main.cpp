#include "FindMaxEx.h"

using namespace std;

struct Sportsman
{
private:
    string m_name;
    int m_height;
    int m_weight;
public:
    Sportsman()
    {
        m_name = "NoName";
        m_height = 0;
        m_weight = 0;
    }

    Sportsman(string name, int height, int weight)
    {
        m_name = name;
        m_height = height;
        m_weight = weight;
    }

    string GetName()
    {
        return m_name;
    }

    int GetHeight()
    {
        return m_height;
    }

    int GetWeight()
    {
        return m_weight;
    }

    friend ostream& operator<<(ostream& os, const Sportsman& sprt);
};

int main()
{
    auto isSportsmanLessByHeight = [](Sportsman a, Sportsman b) { return a.GetHeight() < b.GetHeight(); };
    auto isSportsmanLessByWeight = [](Sportsman a, Sportsman b) { return a.GetWeight() < b.GetWeight(); };

    Sportsman sportsman1 = Sportsman("Vova Pushkin", 180, 73);
    Sportsman sportsman2 = Sportsman("Viktor Dudkin", 170, 82);
    Sportsman sportsman3 = Sportsman("Alex Porin", 172, 90);

    vector<Sportsman> sportsmans = vector<Sportsman>{ sportsman1, sportsman2, sportsman3 };

    Sportsman greatestHeightSportsman;
    Sportsman greatestWeightSportsman;
    FindMax(sportsmans, greatestHeightSportsman, isSportsmanLessByHeight);
    FindMax(sportsmans, greatestWeightSportsman, isSportsmanLessByWeight);

    cout << "Greatest height: \n" << greatestHeightSportsman << endl << endl;
    cout << "Greatest weight: \n" << greatestWeightSportsman << endl << endl;
}

ostream& operator<<(ostream& os, const Sportsman& sprt)
{
    os << "Name: " << sprt.m_name << endl << "Height: " << sprt.m_height << endl << "Weight: " << sprt.m_weight;
    return os;
}
