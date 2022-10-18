const colors = require('tailwindcss/colors')
const defaultTheme = require('tailwindcss/defaultTheme');
module.exports = {
    content: ["**/*.razor", "**/*.cshtml", "**/*.html", "**/*.cs"],
    theme: {
        colors: {
            primary: {
                50: '#eaeaec',
                100: '#d4d6d9',
                200: '#bfc1c6',
                300: '#aaacb3',
                400: '#9598a1',
                500: '#7f838e',    
                600: '#6a6e7b',
                700: '#555968',
                800: '#3f4555',
                900: '#2A3042'
            },
            info: {
                50: '#e6f1fa',
                100: '#cce3f4',
                200: '#b3d6ef',
                300: '#99c8e9',
                400: '#80bae4',
                500: '#66acdf',
                600: '#4d9ed9',
                700: '#3391d4',
                800: '#1a83ce',
                900: '#0075C9'
            },
            secondary: {
                50: '#fbfcfd',
                100: '#f7f9fc',
                200: '#f4f6fa',
                300: '#f0f3f9',
                400: '#ecf1f7',
                500: '#e8eef5',
                600: '#e4ebf4',
                700: '#e1e8f2',
                800: '#d9e2ef',
                900: '#64748b'
            },            
            success: {
                50: '#e9f9ef',
                100: '#d3f3df',
                200: '#bdeecf',
                300: '#a7e8bf',
                400: '#91e2af',
                500: '#7adc9e',
                600: '#64d68e',
                700: '#4ed17e',
                800: '#38cb6e',
                900:'#22C55E'
            },
            danger: {
                50: '#faf0eb',
                100: '#ecd1d4',
                200: '#e2babe',
                300: '#d9a3a8',
                400: '#cf8c93',
                500: '#c5757d',
                600: '#bc5e67',
                700: '#b24751',
                800: '#a9303c',
                900:"#9F1926"
            },
            warning: {
                50: '#fef1e8',
                100: '#fee3d0',
                200: '#fdd5b9',
                300: '#fdc7a2',
                400: '#fcb98b',
                500: '#fbab73',
                600: '#fb9d5c',
                700: '#fa8f45',
                800: '#fa812d',
                900:"#F97316"
            },
            light: {
                50: '#fefefe',
                100: '#fcfdfe',
                200: '#fbfcfd',
                300: '#f9fbfc',
                400: '#f8fafc',
                500: '#f7f8fb',
                600: '#f5f7fa',
                700: '#f4f6f9',
                800: '#f2f5f9',
                900:"#f1f4f8"
            },
            dark: {
                50: '#e7e8ea',
                100: '#cfd1d4',
                200: '#b7b9bf',
                300: '#9fa2aa',
                400: '#878b95',
                500: '#6f747f',
                600: '#575d6a',
                700: '#3f4555',
                800: '#272e3f',
                900:"#0F172A"
            },
            transparent: 'transparent',
            current: 'currentColor',
            black: colors.black,
            white: colors.white,
            slate: colors.slate,
            gray: colors.gray,
            zinc: colors.zinc,
            neutral: colors.neutral,
            stone: colors.stone,
            red: colors.red,
            orange: colors.orange,
            amber: colors.amber,
            yellow: colors.yellow,
            lime: colors.lime,
            green: colors.green,
            emerald: colors.emerald,
            teal: colors.teal,
            cyan: colors.cyan,
            sky: colors.sky,
            blue: colors.blue,
            indigo: colors.indigo,
            violet: colors.violet,
            purple: colors.purple,
            fuchsia: colors.fuchsia,
            pink: colors.pink,
            rose: colors.rose,
        },
        fontSize: {
            'xs': '0.625rem',
            'sm': '0.75rem',
            'md': '0.8125rem',
            'base': '0.875rem',
            'lg': '1rem',
            'xl': '1.125rem',
            '2xl': '1.25rem',
            '3xl': '1.5rem',
            '4xl': '2rem',
            '5xl': '2.25rem',
            '6xl': '2.5rem',
            '7xl': '3rem',
            '8xl': '4rem',
            '9xl': '6rem',
            '10xl': '8rem'
        },
        extend: {
            animation: {
                'spin-slow': 'spin 3s linear infinite'
            },
            flex: {
                '0': '0 0 auto'
            },
            fontFamily: {
                sans: `"Inter var", ${defaultTheme.fontFamily.sans.join(',')}`,
                mono: `"IBM Plex Mono", ${defaultTheme.fontFamily.mono.join(',')}`
            },
            opacity: {
                12: '0.12',
                38: '0.38',
                87: '0.87'
            },
            rotate: {
                '-270': '270deg',
                '15': '15deg',
                '30': '30deg',
                '60': '60deg',
                '270': '270deg'
            },
            scale: {
                '-1': '-1'
            },
            zIndex: {
                '-1': -1,
                '49': 49,
                '60': 60,
                '70': 70,
                '80': 80,
                '90': 90,
                '99': 99,
                '999': 999,
                '9999': 9999,
                '99999': 99999
            },
            spacing: {
                '13': '3.25rem',
                '15': '3.75rem',
                '18': '4.5rem',
                '22': '5.5rem',
                '26': '6.5rem',
                '30': '7.5rem',
                '50': '12.5rem',
                '90': '22.5rem'
            },
            /**
             * Extended spacing values for width and height utilities.
             * This way, we won't be adding these to other utilities
             * that use 'spacing' config to keep the file size
             * smaller by not generating useless utilities such as
             * p-1/4 or m-480.
             */
            extendedSpacing: {
                // Fractional values
                '1/2': '50%',
                '1/3': '33.333333%',
                '2/3': '66.666667%',
                '1/4': '25%',
                '2/4': '50%',
                '3/4': '75%',

                // Bigger values
                '100': '25rem',
                '120': '30rem',
                '128': '32rem',
                '140': '35rem',
                '160': '40rem',
                '180': '45rem',
                '192': '48rem',
                '200': '50rem',
                '240': '60rem',
                '256': '64rem',
                '280': '70rem',
                '320': '80rem',
                '360': '90rem',
                '400': '100rem',
                '480': '120rem'
            },
            height: theme => ({
                ...theme('extendedSpacing')
            }),
            minHeight: theme => ({
                ...theme('spacing'),
                ...theme('extendedSpacing')
            }),
            maxHeight: theme => ({
                ...theme('extendedSpacing'),
                none: 'none'
            }),
            width: theme => ({
                ...theme('extendedSpacing')
            }),
            minWidth: theme => ({
                ...theme('spacing'),
                ...theme('extendedSpacing'),
                screen: '100vw'
            }),
            maxWidth: theme => ({
                ...theme('spacing'),
                ...theme('extendedSpacing'),
                screen: '100vw'
            }),

            // @tailwindcss/typography
            typography: (theme) => ({
                DEFAULT: {
                    css: {
                        color: 'var(--fuse-text-default)',
                        '[class~="lead"]': {
                            color: 'var(--fuse-text-secondary)'
                        },
                        a: {
                            color: 'var(--fuse-primary-500)'
                        },
                        strong: {
                            color: 'var(--fuse-text-default)'
                        },
                        'ol > li::before': {
                            color: 'var(--fuse-text-secondary)'
                        },
                        'ul > li::before': {
                            backgroundColor: 'var(--fuse-text-hint)'
                        },
                        hr: {
                            borderColor: 'var(--fuse-border)'
                        },
                        blockquote: {
                            color: 'var(--fuse-text-default)',
                            borderLeftColor: 'var(--fuse-border)'
                        },
                        h1: {
                            color: 'var(--fuse-text-default)'
                        },
                        h2: {
                            color: 'var(--fuse-text-default)'
                        },
                        h3: {
                            color: 'var(--fuse-text-default)'
                        },
                        h4: {
                            color: 'var(--fuse-text-default)'
                        },
                        'figure figcaption': {
                            color: 'var(--fuse-text-secondary)'
                        },
                        code: {
                            color: 'var(--fuse-text-default)',
                            fontWeight: '500'
                        },
                        'a code': {
                            color: 'var(--fuse-primary)'
                        },
                        pre: {
                            color: theme('colors.white'),
                            backgroundColor: theme('colors.gray.800')
                        },
                        thead: {
                            color: 'var(--fuse-text-default)',
                            borderBottomColor: 'var(--fuse-border)'
                        },
                        'tbody tr': {
                            borderBottomColor: 'var(--fuse-border)'
                        },
                        'ol[type="A" s]': false,
                        'ol[type="a" s]': false,
                        'ol[type="I" s]': false,
                        'ol[type="i" s]': false
                    }
                },
                sm: {
                    css: {
                        code: {
                            fontSize: '1em'
                        },
                        pre: {
                            fontSize: '1em'
                        },
                        table: {
                            fontSize: '1em'
                        }
                    }
                }
            })
        },
        screens: {
            'sm': '640px',
            // => @media (min-width: 640px) { ... }

            'md': '768px',
            // => @media (min-width: 768px) { ... }

            'lg': '1024px',
            // => @media (min-width: 1024px) { ... }

            'xl': '1280px',
            // => @media (min-width: 1280px) { ... }

            '2xl': '1536px',
            // => @media (min-width: 1536px) { ... }
        }
    },
    variants: {
        accessibility: [],
        alignContent: ['responsive'],
        alignItems: ['responsive'],
        alignSelf: ['responsive'],
        animation: [],
        backgroundAttachment: [],
        backgroundClip: [],
        backgroundColor: ['dark', 'responsive', 'group-hover', 'hover', 'focus', 'focus-within'],
        backgroundImage: [],
        backgroundOpacity: ['dark', 'hover'],
        backgroundPosition: [],
        backgroundRepeat: [],
        backgroundSize: [],
        borderCollapse: [],
        borderColor: ['dark', 'group-hover', 'hover', 'focus', 'focus-within'],
        borderOpacity: ['group-hover', 'hover'],
        borderRadius: ['responsive'],
        borderStyle: [],
        borderWidth: ['dark', 'responsive', 'first', 'last', 'odd', 'even'],
        boxShadow: ['dark', 'responsive', 'hover', 'focus-within'],
        boxSizing: [],
        cursor: [],
        display: ['dark', 'responsive', 'hover', 'group-hover'],
        divideColor: ['dark'],
        divideOpacity: [],
        divideStyle: [],
        divideWidth: ['responsive'],
        fill: [],
        flex: ['responsive'],
        flexDirection: ['responsive'],
        flexGrow: ['responsive'],
        flexShrink: ['responsive'],
        flexWrap: ['responsive'],
        fontFamily: [],
        fontSize: ['responsive'],
        fontSmoothing: [],
        fontStyle: ['responsive'],
        fontVariantNumeric: [],
        fontWeight: ['responsive'],
        gap: ['responsive'],
        gridAutoColumns: ['responsive'],
        gridAutoFlow: ['responsive'],
        gridAutoRows: ['responsive'],
        gridColumn: ['responsive'],
        gridColumnEnd: ['responsive'],
        gridColumnStart: ['responsive'],
        gridRow: ['responsive'],
        gridRowEnd: ['responsive'],
        gridRowStart: ['responsive'],
        gridTemplateColumns: ['responsive'],
        gridTemplateRows: ['responsive'],
        height: ['responsive'],
        inset: ['responsive'],
        justifyContent: ['responsive'],
        justifyItems: ['responsive'],
        justifySelf: ['responsive'],
        letterSpacing: ['responsive'],
        lineHeight: ['responsive'],
        listStylePosition: [],
        listStyleType: [],
        margin: ['responsive'],
        maxHeight: ['responsive'],
        maxWidth: ['responsive'],
        minHeight: ['responsive'],
        minWidth: ['responsive'],
        objectFit: ['responsive'],
        objectPosition: ['responsive'],
        opacity: ['responsive', 'group-hover', 'hover'],
        order: ['responsive'],
        outline: [],
        overflow: ['responsive'],
        overscrollBehavior: ['responsive'],
        padding: ['responsive'],
        placeContent: ['responsive'],
        placeItems: ['responsive'],
        placeSelf: ['responsive'],
        pointerEvents: ['responsive'],
        position: ['responsive'],
        resize: [],
        ringColor: ['dark', 'group-hover'],
        ringOffsetColor: ['dark'],
        ringOffsetWidth: [],
        ringOpacity: [],
        ringWidth: [],
        rotate: [],
        scale: [],
        skew: [],
        space: ['responsive'],
        stroke: ['responsive'],
        strokeWidth: ['responsive'],
        tableLayout: ['responsive'],
        textAlign: ['responsive'],
        textColor: ['dark', 'group-hover', 'hover'],
        textDecoration: ['group-hover', 'hover'],
        textOpacity: ['group-hover', 'hover'],
        textOverflow: ['responsive'],
        textTransform: [],
        transform: [],
        transformOrigin: [],
        transitionDelay: [],
        transitionDuration: [],
        transitionProperty: [],
        transitionTimingFunction: [],
        translate: ['hover'],
        userSelect: ['responsive'],
        visibility: ['responsive'],
        whitespace: ['responsive'],
        width: ['responsive'],
        wordBreak: ['responsive'],
        zIndex: ['responsive']
    },
    plugins: [],
    safelist: []
}



