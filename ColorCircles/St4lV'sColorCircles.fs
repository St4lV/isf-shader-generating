/*{
    "DESCRIPTION": "Generating shader: color circles with adjustable speed & colors",
    "CREDIT": "St4lV",
    "ISFVSN": "2",
    "CATEGORIES": [
        "Example"
    ],
    "INPUTS": [
        {
            "NAME": "speed",
            "TYPE": "float",
            "DEFAULT": 5,
            "MIN": 0,
            "MAX": 100
        },
        {
            "NAME": "color1",
            "TYPE": "color",
            "DEFAULT": [
                1.0,
                1.0,
                1.0,
                1.0
            ]
        },
        {
            "NAME": "color2",
            "TYPE": "color",
            "DEFAULT": [
                0.0,
                0.0,
                0.0,
                1.0
            ]
        },
        {
            "NAME": "color3",
            "TYPE": "color",
            "DEFAULT": [
                0.0,
                0.9,
                1.0,
                1.0
            ]
        }
    ],
    "PASSES": [
        {
            "TARGET":"bufferVariableNameA",
            "WIDTH": "$WIDTH/16.0",
            "HEIGHT": "$HEIGHT/16.0"
        },
        {
            "DESCRIPTION": "Render at full resolution"
        }
    ]
    
}*/

#define PI 3.14159265358979323846

void main() {
    vec2 uv = gl_FragCoord.xy / RENDERSIZE.xy;
    vec2 center = vec2(0.5, 0.5);

    float aspectRatio = RENDERSIZE.x / RENDERSIZE.x;
    uv.x *= aspectRatio;

    float baseSpeed = 0.1;
    float time = ((TIME * baseSpeed) * (speed - 50.0))/10.0;

    float maxScreenSize = min(RENDERSIZE.x, RENDERSIZE.y);

    float minRadius1 = 1.2 * maxScreenSize;
    float maxRadius1 = 1.4 * maxScreenSize;

    float minRadius2 = 1.0 * maxScreenSize;
    float maxRadius2 = 1.2 * maxScreenSize;

    float minRadius3 = 0.8 * maxScreenSize;
    float maxRadius3 = 1.0 * maxScreenSize;

    float minRadius4 = 0.6 * maxScreenSize;
    float maxRadius4 = 0.8 * maxScreenSize;

    float minRadius5 = 0.4 * maxScreenSize;
    float maxRadius5 = 0.6 * maxScreenSize;

    float minRadius6 = 0.2 * maxScreenSize;
    float maxRadius6 = 0.4 * maxScreenSize;

    float minRadius7 = 0.0 * maxScreenSize;
    float maxRadius7 = 0.2 * maxScreenSize;

    float cycleDuration = 0.1;

    float phase = mod(time, cycleDuration * 3.0);

    vec4 currentColor1, currentColor2, currentColor3, currentColor4, currentColor5, currentColor6, currentColor7;
    float radius1, radius2, radius3, radius4, radius5, radius6, radius7;

    if (phase < cycleDuration) {
        float t = phase / cycleDuration;
        radius1 = mix(minRadius1, maxRadius1, t);
        currentColor1 = color1;
    } else if (phase < 2.0 * cycleDuration) {
        float t = (phase - cycleDuration) / cycleDuration;
        radius1 = mix(minRadius1, maxRadius1, t);
        currentColor1 = color2;
    } else {
        float t = (phase - 2.0 * cycleDuration) / cycleDuration;
        radius1 = mix(minRadius1, maxRadius1, t);
        currentColor1 = color3;
    }

    if (phase < cycleDuration) {
        float t = phase / cycleDuration;
        radius2 = mix(minRadius2, maxRadius2, t);
        currentColor2 = color2;
    } else if (phase < 2.0 * cycleDuration) {
        float t = (phase - cycleDuration) / cycleDuration;
        radius2 = mix(minRadius2, maxRadius2, t);
        currentColor2 = color3;
    } else {
        float t = (phase - 2.0 * cycleDuration) / cycleDuration;
        radius2 = mix(minRadius2, maxRadius2, t);
        currentColor2 = color1;
    }

    if (phase < cycleDuration) {
        float t = phase / cycleDuration;
        radius3 = mix(minRadius3, maxRadius3, t);
        currentColor3 = color3;
    } else if (phase < 2.0 * cycleDuration) {
        float t = (phase - cycleDuration) / cycleDuration;
        radius3 = mix(minRadius3, maxRadius3, t);
        currentColor3 = color1;
    } else {
        float t = (phase - 2.0 * cycleDuration) / cycleDuration;
        radius3 = mix(minRadius3, maxRadius3, t);
        currentColor3 = color2;
    }

    if (phase < cycleDuration) {
        float t = phase / cycleDuration;
        radius4 = mix(minRadius4, maxRadius4, t);
        currentColor4 = color1;
    } else if (phase < 2.0 * cycleDuration) {
        float t = (phase - cycleDuration) / cycleDuration;
        radius4 = mix(minRadius4, maxRadius4, t);
        currentColor4 = color2;
    } else {
        float t = (phase - 2.0 * cycleDuration) / cycleDuration;
        radius4 = mix(minRadius4, maxRadius4, t);
        currentColor4 = color3;
    }

    if (phase < cycleDuration) {
        float t = phase / cycleDuration;
        radius5 = mix(minRadius5, maxRadius5, t);
        currentColor5 = color2;
    } else if (phase < 2.0 * cycleDuration) {
        float t = (phase - cycleDuration) / cycleDuration;
        radius5 = mix(minRadius5, maxRadius5, t);
        currentColor5 = color3;
    } else {
        float t = (phase - 2.0 * cycleDuration) / cycleDuration;
        radius5 = mix(minRadius5, maxRadius5, t);
        currentColor5 = color1;
    }

    if (phase < cycleDuration) {
        float t = phase / cycleDuration;
        radius6 = mix(minRadius6, maxRadius6, t);
        currentColor6 = color3;
    } else if (phase < 2.0 * cycleDuration) {
        float t = (phase - cycleDuration) / cycleDuration;
        radius6 = mix(minRadius6, maxRadius6, t);
        currentColor6 = color1;
    } else {
        float t = (phase - 2.0 * cycleDuration) / cycleDuration;
        radius6 = mix(minRadius6, maxRadius6, t);
        currentColor6 = color2;
    }

    if (phase < cycleDuration) {
        float t = phase / cycleDuration;
        radius7 = mix(minRadius7, maxRadius7, t);
        currentColor7 = color1;
    } else if (phase < 2.0 * cycleDuration) {
        float t = (phase - cycleDuration) / cycleDuration;
        radius7 = mix(minRadius7, maxRadius7, t);
        currentColor7 = color2;
    } else {
        float t = (phase - 2.0 * cycleDuration) / cycleDuration;
        radius7 = mix(minRadius7, maxRadius7, t);
        currentColor7 = color3;
    }

    float dist = distance(uv * RENDERSIZE.xy, center * RENDERSIZE.xy);
    vec4 pixelColor = vec4(0.0, 0.0, 0.0, 1.0);

    if (dist < radius1) {
        pixelColor = currentColor1;
    }
    if (dist < radius2) {
        pixelColor = currentColor2;
    }
    if (dist < radius3) {
        pixelColor = currentColor3;
    }
    if (dist < radius4) {
        pixelColor = currentColor4;
    }
    if (dist < radius5) {
        pixelColor = currentColor5;
    }
    if (dist < radius6) {
        pixelColor = currentColor6;
    }
    if (dist < radius7) {
        pixelColor = currentColor7;
    }

    gl_FragColor = pixelColor;
}
