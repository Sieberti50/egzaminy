package com.example.notatnik;

import java.util.Date;

public class Notatka {
    public String tytul;
    public String tresc;
    public boolean wazna;
    public Date dataDodania;

    public Notatka(String tytul, String tresc, boolean wazna) {
        this.tytul = tytul;
        this.tresc = tresc;
        this.wazna = wazna;
        this.dataDodania = new Date();
    }

    public Notatka(String tytul) {
        this.tytul = tytul;
        this.tresc = "";
        this.wazna = false;
        this.dataDodania = new Date();
    }

    @Override
    public String toString() {
        return tytul + "\n" + tresc;
    }
}