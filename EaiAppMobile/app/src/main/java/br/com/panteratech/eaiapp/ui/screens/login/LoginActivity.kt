package br.com.panteratech.eaiapp.ui.screens.login

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.layout.*
import androidx.compose.material.MaterialTheme
import androidx.compose.material.Surface
import androidx.compose.material.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.res.stringResource
import androidx.compose.ui.unit.*
import br.com.panteratech.eaiapp.R
import br.com.panteratech.eaiapp.ui.components.shared.button.ButtonDefault
import br.com.panteratech.eaiapp.ui.components.shared.input.InputDefault
import br.com.panteratech.eaiapp.ui.theme.EaiAppTheme

class LoginActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            EaiAppTheme {
                Surface(color = MaterialTheme.colors.background) {
                    LoginContainer()
                }
            }
        }
    }
}

@Composable
fun Greeting() {
    Column(
        Modifier.width(200.dp)
    ) {
        Text(
            text = stringResource(id = R.string.login_greeting),
            style = MaterialTheme.typography.h1,
            fontSize = 18.sp,
        )
    }
}

@Composable
fun LoginContainer(){
    Column (
        Modifier
            .fillMaxWidth()
            .fillMaxHeight()
            .padding(horizontal = 30.dp, vertical = 50.dp)
            ){
        Greeting()
        InputDefault(label = "Email")
        InputDefault(label = "Senha")
        ButtonDefault(text = "ENTRAR", onClick = null)
    }
}

