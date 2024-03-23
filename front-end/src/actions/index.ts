'use server'

import { redirect } from 'next/navigation'

export async function fetchRecipeHeaders() {
    const data = await fetch('http://localhost:5034/recipes')

    return data.json()
}

export async function fetchRecipeDetails(id: number) {
    const data = await fetch(`http://localhost:5034/recipes/${id.toString()}`)

    if (!data) {
        throw new Error("Couldn't find that recipe!")
    }

    return data.json()

}

export async function search(formData: FormData) {
    const term = formData.get('term')

    if (typeof term !== 'string' || !term) {
        redirect('/')

    }

    redirect(`/search?term=${term}`)
}