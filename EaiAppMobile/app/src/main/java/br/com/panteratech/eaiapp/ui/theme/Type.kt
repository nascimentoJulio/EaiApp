package br.com.panteratech.eaiapp.ui.theme

import androidx.compose.material.Typography
import androidx.compose.ui.text.TextStyle
import androidx.compose.ui.text.font.Font
import androidx.compose.ui.text.font.FontFamily
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.unit.sp
import br.com.panteratech.eaiapp.R

val Ruda = FontFamily(
    Font(R.font.ruda_bold),
    Font(R.font.ruda_regular, FontWeight.Bold),
)

val Typography = Typography(
    h1 = TextStyle(
        fontFamily = Ruda,
        fontSize = 14.sp,
        fontWeight = FontWeight.Bold
    ),
    body1 = TextStyle(
        fontFamily = Ruda,
        fontWeight = FontWeight.Normal,
        fontSize = 16.sp
    ),
    button = TextStyle(
        fontFamily = Ruda,
        fontWeight = FontWeight.Bold,
        fontSize = 18.sp
    )

)