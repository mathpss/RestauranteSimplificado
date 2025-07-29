import Skeleton from "react-loading-skeleton"
import { WrapperCardSkeleton } from "./styles"

export const CardSkeleton = ({ cards }: { cards: number }) => {

    return (<>
       { Array(cards).fill(0).map((_,index: number) =>
            <WrapperCardSkeleton key={index}>
                <Skeleton />
            </WrapperCardSkeleton>
        )}
</>
    )
}