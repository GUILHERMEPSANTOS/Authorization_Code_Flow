import { NextApiRequest, NextApiResponse } from "next";
import { AuthOptions } from "next-auth";
import NextAuth from "next-auth/next";
import KeycloakProvider from "next-auth/providers/keycloak";

type KeycloakOptionsType = { wellKnown: string, authorizationEndpoint: string }

const authOptions = async (): Promise<AuthOptions> => {
    var response = await fetch("http://localhost:5278/idp/settings");
    var keycloakOptions: KeycloakOptionsType = await response.json();

    return {
        providers: [
            KeycloakProvider({
                clientId: `${process.env.CLIENT_ID}`,
                clientSecret: `${process.env.CLIENT_SECRET}`,
                issuer: keycloakOptions.authorizationEndpoint,
                wellKnown: keycloakOptions.wellKnown,
            })
        ],
        callbacks: {

        }
    }
};

export async function POST(req: NextApiRequest, res: NextApiResponse) {
    const options = await authOptions();

    return await NextAuth(req, res, options)
}

export async function GET(req: NextApiRequest, res: NextApiResponse) {
    const options = await authOptions();

    return await NextAuth(req, res, options)
}