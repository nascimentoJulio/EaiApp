package br.com.panteratech.eaiapp.ui.screens.login

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.text.ClickableText
import androidx.compose.material.MaterialTheme
import androidx.compose.material.Surface
import androidx.compose.material.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.stringResource
import androidx.compose.ui.text.AnnotatedString
import androidx.compose.ui.text.TextStyle
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import br.com.panteratech.eaiapp.R
import br.com.panteratech.eaiapp.ui.components.shared.button.ButtonDefault
import br.com.panteratech.eaiapp.ui.components.shared.default_text.DefaultText
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
fun LoginContainer() {
    Column(
        Modifier
            .fillMaxWidth()
            .fillMaxHeight()
            .padding(horizontal = 30.dp, vertical = 50.dp)
    ) {
        Greeting()
        FormContainer()
    }
}

@Composable
fun FormContainer() {
    Column(
        horizontalAlignment = Alignment.CenterHorizontally,
        modifier = Modifier.fillMaxWidth()
    ) {
        Spacer(modifier = Modifier.padding(top = 60.dp))

        InputDefault(
            label = stringResource(id = R.string.email),
            placeholder = stringResource(id = R.string.inform_your_email)
        )

        Spacer(modifier = Modifier.padding(top = 45.dp))

        InputDefault(
            label = stringResource(id = R.string.password),
            placeholder = stringResource(id = R.string.inform_your_password)
        )

        Spacer(modifier = Modifier.padding(top = 10.dp))
        Row {
            DefaultText(
                text = stringResource(id = R.string.dont_have_an_account),
                color = Color.Black
            )
            Spacer(modifier = Modifier.padding(horizontal = 4.dp))
            ClickableText(
                onClick = {
                },
                text = AnnotatedString(text = stringResource(id = R.string.create_here)),
                style = TextStyle(
                    color = MaterialTheme.colors.primary,
                    fontFamily = MaterialTheme.typography.body1.fontFamily
                )
            )
        }
        Spacer(modifier = Modifier.padding(top = 150.dp))

        ButtonDefault(text = stringResource(id = R.string.login), onClick = null)
    }
}
