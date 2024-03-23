import { fetchRecipeHeaders } from "@/actions";
import Link from "next/link";

interface RecipeHeader {
    id: number;
    title: string;
    servings: number
}

export default async function RecipesList() {
    const recipes = await fetchRecipeHeaders()

    const renderedRecipes = recipes.map((rec: RecipeHeader) => {
        return (
            <div key={rec.id}>


                <Link href={`recipes/${rec.id}`}>{rec.title}</Link>


            </div>
        )
    })

    return (
        <div >
            {renderedRecipes}
        </div>
    )
}