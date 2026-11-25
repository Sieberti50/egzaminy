package com.example.mobile;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    private int licznikPolubien = 0;
    private TextView napisPolubienia;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        napisPolubienia = findViewById(R.id.napisPolubienia);
        Button przyciskPolub = findViewById(R.id.przyciskPolub);
        Button przyciskUsun = findViewById(R.id.przyciskUsun);

        przyciskPolub.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                licznikPolubien++;
                pokazLicznik();
            }
        });

        przyciskUsun.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (licznikPolubien > 0) {
                    licznikPolubien--;
                }
                pokazLicznik();
            }
        });
    }

    private void pokazLicznik() {
        napisPolubienia.setText(licznikPolubien + " polubień");
    }
}