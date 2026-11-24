package com.example.loginapp;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    private EditText poleEmail;
    private EditText poleHaslo;
    private EditText polePowtorzHaslo;
    private TextView tekstKomunikat;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        poleEmail = findViewById(R.id.poleEmail);
        poleHaslo = findViewById(R.id.poleHaslo);
        polePowtorzHaslo = findViewById(R.id.polePowtorzHaslo);
        tekstKomunikat = findViewById(R.id.tekstKomunikat);
        Button przyciskZatwierdz = findViewById(R.id.przyciskZatwierdz);

        tekstKomunikat.setText("Autor 12345678901");

        przyciskZatwierdz.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View widok) {
                sprawdzDane();
            }
        });
    }

    private void sprawdzDane() {
        String email = poleEmail.getText().toString();
        String haslo = poleHaslo.getText().toString();
        String powtorzoneHaslo = polePowtorzHaslo.getText().toString();

        if (!email.contains("@")) {
            tekstKomunikat.setText("Nieprawidłowy adres e-mail");
        } else if (!haslo.equals(powtorzoneHaslo)) {
            tekstKomunikat.setText("Hasła się różnią");
        } else {
            tekstKomunikat.setText("Witaj " + email);
        }
    }
}