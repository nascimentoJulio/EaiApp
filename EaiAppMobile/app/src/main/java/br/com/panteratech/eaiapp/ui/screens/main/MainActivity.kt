package br.com.panteratech.eaiapp.ui.screens.main

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.layout.Column
import androidx.compose.material.MaterialTheme
import androidx.compose.material.Surface
import androidx.compose.material.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.tooling.preview.Preview
import br.com.panteratech.eaiapp.ui.theme.EaiAppTheme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            EaiAppTheme {
                // A surface container using the 'background' color from the theme
                Surface(color = MaterialTheme.colors.background) {
                    Greeting("Android")
                }
            }
        }
    }
}

@Composable
fun Greeting(name: String) {
    Column {
        Text(text = "Hello $name with h1 bold", style = MaterialTheme.typography.h1)
        Text(text = "Hello $name with body regular", style = MaterialTheme.typography.body1)
    }
}

@Preview(showBackground = true)
@Composable
fun DefaultPreview() {
    EaiAppTheme {
        Greeting("Android")
    }
}