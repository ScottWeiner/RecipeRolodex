import { fetchRecipeDetails } from "@/actions";


interface RecipeShowPageProps {
    params: {
        slug: number;
    }
}

export default async function RecipieShowPage({ params }: RecipeShowPageProps) {

    const data = await fetchRecipeDetails(params.slug)

    if (!data) {
        throw Error("Uh oh, spaghetti-os!")
    }

    console.log(data.steps.length)

    return (
        <div>
            <div> Recipe show page for recipe {data.id}</div>
            <div>Title: {data.title}</div>
            <div>Servings: {data.servings}</div>
            <div>Details:</div>
            {data.details && data.details.map((det: any) => {
                return (
                    <div key={det.id}>
                        <p>{det.id}</p>
                        <p>{det.ingredient}</p>
                        <p>{det.quantity}</p>
                        <p>{det.measure}</p>
                    </div>
                )
            })}
            <div>Steps:</div>
            <div>
                {data.steps.map((step: any) => {
                    return (
                        <div key={step.id}>
                            <p>{step.id}: {step.description}</p>
                            
                        </div>)
                })}
            </div>
        </div>
    )
}