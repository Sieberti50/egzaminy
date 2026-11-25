package com.example.notatnik;

import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;

import androidx.appcompat.app.AppCompatActivity;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    ArrayList<Notatka> notatki = new ArrayList<>();
    ArrayAdapter<Notatka> adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ListView listaNotatek = findViewById(R.id.listaNotatek);
        EditText poleTytul = findViewById(R.id.poleTytul);
        EditText poleTresc = findViewById(R.id.poleTresc);
        Button przyciskDodaj = findViewById(R.id.przyciskDodaj);

        notatki.add(new Notatka("tenis", "Gra z Ewą w poniedziałek", true));

        adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, notatki);
        listaNotatek.setAdapter(adapter);

        przyciskDodaj.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String tytul = poleTytul.getText().toString();
                String tresc = poleTresc.getText().toString();

                notatki.add(new Notatka(tytul, tresc, false));
                adapter.notifyDataSetChanged();
            }
        });
    }
}